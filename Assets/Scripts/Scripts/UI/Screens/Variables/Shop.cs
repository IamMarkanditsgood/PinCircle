using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : BasicScreen
{
    [SerializeField] private Button HomeButton;

    [SerializeField] private Button[] _shopButtons;
    [SerializeField] private int[] _prices;
    [SerializeField] private TMP_Text[] _shopText;
    [SerializeField] private Sprite[] _playerSprites;
    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private GameObject[] _itemsCloseds;

    [SerializeField] private TMP_Text _score;

    private TextManager _textManager = new TextManager();

    private void Start()
    {
        HomeButton.onClick.AddListener(Home);

        for(int i = 0; i < _shopButtons.Length; i++)
        {
            int index = i;
            _shopButtons[index].onClick.AddListener(() => ShopButtonPressed(index));
        }
        if (!SaveManager.PlayerPrefs.IsSaved(GameSaveKeys.BoughtSkins))
        {
            List<int> bought = new List<int>();
            bought.Add(0);
            
            SaveManager.PlayerPrefs.SaveIntList(GameSaveKeys.BoughtSkins, bought);
        }
    }

    private void OnDestroy()
    {
        HomeButton.onClick.RemoveListener(Home);

        for (int i = 0; i < _shopButtons.Length; i++)
        {
            int index = i;
            _shopButtons[index].onClick.RemoveListener(() => ShopButtonPressed(index));
        }
    }

    public override void ResetScreen()
    {

    }

    public override void SetScreen()
    {
        foreach(var text in _shopText)
        {
            text.text = "Choose";
        }

        int savedSkin = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.SavedPlayer);
        _shopText[savedSkin].text = "Used";

        if (SaveManager.PlayerPrefs.IsSaved(GameSaveKeys.BoughtSkins))
        {
            
            List<int> bought = SaveManager.PlayerPrefs.LoadIntList(GameSaveKeys.BoughtSkins);
            
            foreach (var skin in bought)
            {
                _itemsCloseds[skin].SetActive(false);
            }
        }
        SetText();
    }

    private void SetText()
    {
        int coins = ResourcesManager.Instance.GetResource(ResourceTypes.Score);
        _textManager.SetText(coins, _score, true);


    }

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.MainMenu);
    }
    
    private void ShopButtonPressed(int index)
    {
        List<int> bought = SaveManager.PlayerPrefs.LoadIntList(GameSaveKeys.BoughtSkins);
        foreach(var item in bought)
        {
            if(item == index)
            {
                SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.SavedPlayer, index);

                foreach (var text in _shopText)
                {
                    
                    text.text = "Choose";
                }

                int savedSkin = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.SavedPlayer);
                _player.sprite = _playerSprites[savedSkin];
                _shopText[savedSkin].text = "Used";
                return;
            }
        }

        if(ResourcesManager.Instance.IsEnoughResource(ResourceTypes.Score, _prices[index]))
        {
            ResourcesManager.Instance.ModifyResource(ResourceTypes.Score, -_prices[index]);

            List<int> newBoungt = SaveManager.PlayerPrefs.LoadIntList(GameSaveKeys.BoughtSkins);
            newBoungt.Add(index);
            SaveManager.PlayerPrefs.SaveIntList(GameSaveKeys.BoughtSkins, newBoungt);

            SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.SavedPlayer, index);

            foreach (var text in _shopText)
            {
                text.text = "Choose";
            }

            int savedSkin = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.SavedPlayer);
            _player.sprite = _playerSprites[savedSkin];
            _shopText[savedSkin].text = "Used";
            _itemsCloseds[savedSkin].SetActive(false);
            SetText();
            return;
        } 
    }
}
