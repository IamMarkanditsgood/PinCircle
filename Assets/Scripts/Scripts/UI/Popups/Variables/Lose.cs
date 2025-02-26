using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lose : BasicPopup
{
    [SerializeField] private TMP_Text _score;

    [SerializeField] private Button _playAgain;

    [SerializeField] private Orbit_Manager _orbitManager;

    private void Start()
    {
        _playAgain.onClick.AddListener(StartAgain);
    }

    private void OnDestroy()
    {
        _playAgain.onClick.RemoveListener(StartAgain);
    }
    public override void ResetPopup()
    {
       
    }

    public override void SetPopup()
    {
        Time.timeScale = 0f;
        _orbitManager.enabled = false;
        Debug.Log(ResourcesManager.Instance.GetResource(ResourceTypes.Score));
        _score.text = ResourcesManager.Instance.GetResource(ResourceTypes.Score).ToString();
    }

    private void StartAgain()
    {
        Time.timeScale = 1;
        _orbitManager.enabled = true;
        ResourcesManager.Instance.ModifyResource(ResourceTypes.Score, 0, true);
        UIManager.Instance.HidePopup(PopupType);
        UIManager.Instance.ShowScreen(ScreenTypes.Game);
    }
}
