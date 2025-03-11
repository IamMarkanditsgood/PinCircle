using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class PreGame : BasicScreen
{
    [SerializeField] private Button _close;
    [SerializeField] private Button _play;
    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
    }
    private void Start()
    {
        _close.onClick.AddListener(Close);
        _play.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Game);
    }

    private void OnDestroy()
    {
        _close.onClick.RemoveListener(Close);
        _play.onClick.RemoveListener(PlayGame);
    }

    private void Close()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.MainMenu);
    }
}
