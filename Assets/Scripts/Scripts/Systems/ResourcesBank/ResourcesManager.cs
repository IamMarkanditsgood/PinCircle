using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour 
{
    public static ResourcesManager Instance { get; private set; }

    public event Action<ResourceTypes, int> OnResourceModified;

    private Dictionary<ResourceTypes, int> _resources = new Dictionary<ResourceTypes, int>();

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        SaveManager.Resources.SaveResource(ResourceTypes.Score, 0);
        InitResourceDictionary(); 
    }

    public int GetResource(ResourceTypes resource)
    {
        return _resources[resource];
    }

    public void ModifyResource(ResourceTypes resource, int updateAmount, bool resetResource = false)
    {
        if (resetResource)
        {
            _resources[resource] = updateAmount;
        }
        else
        {
            _resources[resource] += updateAmount;
        }
        SaveManager.Resources.SaveResource(resource, _resources[resource]);

        if(_resources[ResourceTypes.Score] > SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.BestScore))
        {
            SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.BestScore, _resources[ResourceTypes.Score]);
        }

        if(_resources[resource] == 10)
        {
            SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.FirstTask, 1);
        }

        OnResourceModified?.Invoke(resource, _resources[resource]);
    }

    public bool IsEnoughResource(ResourceTypes resource, int price)
    {
        if (_resources[resource] >= price)
        {
            
            return true;
        }

        return false;
    }

    private void InitResourceDictionary()
    {
        _resources[ResourceTypes.Score] = SaveManager.Resources.LoadResource(ResourceTypes.Score);
    }
}