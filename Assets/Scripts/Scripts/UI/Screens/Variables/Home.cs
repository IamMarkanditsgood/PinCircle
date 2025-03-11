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
    [SerializeField] private Button Game1;
    [SerializeField] private Button Game2;

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
        Game1.onClick.AddListener(PlayGame1);
        Game2.onClick.AddListener(PlayGame2);
    }

    private void PlayGame1()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }
    private void PlayGame2()
    {
        SceneManager.LoadScene("GameScene");
    }
    private void OnDestroy()
    {
        Tasks.onClick.RemoveListener(TasksPressed);
        Shop.onClick.RemoveListener(ShopPressed);
        Info.onClick.RemoveListener(InfoPressed);
        Settings.onClick.RemoveListener(SettingsPressed);
        Game1.onClick.RemoveListener(PlayGame1);
        Game2.onClick.RemoveListener(PlayGame2);
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
