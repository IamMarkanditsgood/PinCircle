using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Home : BasicScreen
{

    [SerializeField] private Button Tasks;
    [SerializeField] private Button Shop;
    [SerializeField] private Button Info;
    [SerializeField] private Button Settings;
    [SerializeField] private Button Play;

    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private Sprite[] _playerSprites;

    [SerializeField] private TMP_Text _bestScore;

    private TextManager _textManager = new TextManager();


    private void Start()
    {
       
        Tasks.onClick.AddListener(TasksPressed);
        Shop.onClick.AddListener(ShopPressed);
        Info.onClick.AddListener(InfoPressed);
        Settings.onClick.AddListener(SettingsPressed);
        Play.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Game);
    }

    private void OnDestroy()
    {
        Tasks.onClick.RemoveListener(TasksPressed);
        Shop.onClick.RemoveListener(ShopPressed);
        Info.onClick.RemoveListener(InfoPressed);
        Settings.onClick.RemoveListener(SettingsPressed);
        Play.onClick.RemoveListener(PlayGame);
    }

    public override void ResetScreen()
    {
 
    }

    public override void SetScreen()
    {
        int bestScore = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.BestScore);
        _textManager.SetText(bestScore, _bestScore, true);

        int savedSkin = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.SavedPlayer);
        _player.sprite = _playerSprites[savedSkin];
    }

    private void ShopPressed()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Shop);
    }
    private void TasksPressed()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Tasks);
    }

    private void SettingsPressed()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Settings);
    }

    private void InfoPressed()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Info);
    }
}
