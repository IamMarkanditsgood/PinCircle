﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerTwo : MonoBehaviour
{
    public static ScoreManagerTwo Instance { get; set; }
    public Text currentScoreLabel, highScoreLabel, currentScoreGameOverLabel, highScoreGameOverLabel;

    public int currentScore, highScore;
    // Start is called before the first frame update

    void Awake()
    {
        //DontDestroyOnLoad(this);

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //init and load highscore
    void Start()
    {
        if (!PlayerPrefs.HasKey(Constants.HIGH_SCORE))
            PlayerPrefs.SetInt(Constants.HIGH_SCORE, 0);

        highScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE);

        UpdateHighScore();
        ResetCurrentScore();
    }

    //save and update highscore
    void UpdateHighScore()
    {
        if (SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.BestScore) < currentScore)
        {
            SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.BestScore, currentScore);
        }
    }

    //update currentscore
    public void UpdateScore(int value)
    {
        currentScore += value;

        if (currentScore > 0 && currentScore % 10 == 0 && GameManagerTwo.Instance.uIManager.gameState == GameState.PLAYING)
            GameManagerTwo.Instance.uIManager.ShowAnimatedText("Amazing!");

        currentScoreLabel.text = currentScore.ToString();
    }

    //reset current score
    public void ResetCurrentScore()
    {
        currentScore = 0;
        UpdateScore(0);
    }

    //update gameover scores
    public void UpdateScoreGameover()
    {
        UpdateHighScore();

        currentScoreGameOverLabel.text = currentScore.ToString();
        highScoreGameOverLabel.text = highScore.ToString();
    }
}
