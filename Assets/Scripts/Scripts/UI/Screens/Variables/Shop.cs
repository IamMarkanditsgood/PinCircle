using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : BasicScreen
{
    [SerializeField] private Button HomeButton;

    [SerializeField] private Button[] _shopButtons;
    [SerializeField] private TMP_Text[] _shopText;
    [SerializeField] private Sprite[] _playerSprites;
    [SerializeField] private SpriteRenderer _player;


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

        SetText();
    }

    private void SetText()
    {
        int coins = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.BestScore);
        _textManager.SetText(coins, _score, true);


    }

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.MainMenu);
    }
    
    private void ShopButtonPressed(int index)
    {
        SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.SavedPlayer, index);
        
        foreach (var text in _shopText)
        {
            text.text = "Choose";
        }

        int savedSkin = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.SavedPlayer);
        _player.sprite = _playerSprites[savedSkin];
        _shopText[savedSkin].text = "Used";
    }
}
