using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    public int coinsToEarn = 10;
    public float CamOffset = 11;
    [HideInInspector]public int coins;
    [Header("References")]
    [HideInInspector]
    public 
        ScoreManager scoreManager;
    [HideInInspector] 
    public
        SoundManager soundManager;
    CanvasManager canvasManager;
    Store store;
    AdMobHandler adHandler;
    PlayerEditor player;

    public static GameManager inst;

    public float GetBounds()
    {
        SpriteRenderer bounds = player.GetComponent<SpriteRenderer>();
        return bounds.bounds.size.x * Screen.height / Screen.width * CamOffset;
    }
    #region Initialize Game
    void Awake()
    {
        inst = this;
    }
    void Start()
    {
        Initialize();
    }
    void Initialize()
    {   
        //setup score
        GameObject scoreObject = GameObject.FindGameObjectWithTag("ScoreText");
        Text scoreText = scoreObject.GetComponent<Text>();
        string gameName = SceneManager.GetActiveScene().name;
        scoreManager = new ScoreManager(scoreText, gameName);
        GetInstance();
        if (store.player == null)
        {
            store.player = player.GetComponent<SpriteRenderer>();
        }
        scoreManager.LoadSaveGameScore();
        CamSetup();
    }
    void GetInstance()
    {
        //adHandler = AdMobHandler.inst;
        canvasManager = CanvasManager.inst;
        store = Store.inst;
        soundManager = SoundManager.inst;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEditor>();

    }
    void CamSetup()
    {
        Camera.main.orthographicSize = GetBounds();

    }
    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region GameEvents
    public void BeginPlay()
    {
        canvasManager.ShowCanvas(0);
        player.Enable(true);
    }
    public void ResetGame()
    {
        canvasManager.ShowCanvas(0);
        canvasManager.ShowCanvas(1);
        ResetVaules();
        Time.timeScale = 1;
    }
    void ResetVaules()
    {
        scoreManager.currentPoints = 0;
        coins = 0;
        player.Reset();
        store.RandomizePlayer();
    }
    public void Lose()
    {
        ThemeManager.inst.OnLose();
        canvasManager.ShowCanvas(1);
        store.SaveCoins(coins);
        //adHandler.LoadAll();
    }
    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Functions
    public void AddCoins()
    {
        coins += coinsToEarn;
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    #endregion
}
