using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BasicScreen
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _pauseButton;

    [SerializeField] private Orbit_Manager _orbitManager;
    [SerializeField] private PolygonCollider2D playerPolygonCollider2D;

    private void Start()
    {
        _homeButton.onClick.AddListener(HomePressed);
        _pauseButton.onClick.AddListener(PausePressed);
    }

    private void OnDestroy()
    {
        _homeButton.onClick.RemoveListener(HomePressed);
        _pauseButton.onClick.RemoveListener(PausePressed);
    }
    public override void ResetScreen()
    {
        _orbitManager.enabled = false;
    }

    public override void SetScreen()
    {
        playerPolygonCollider2D.enabled = true;
        _score.text = "0";
        _orbitManager.enabled = true;
        _orbitManager.Reset();
    }

    private void HomePressed()
    {
        playerPolygonCollider2D.enabled = false;
        ResourcesManager.Instance.ModifyResource(ResourceTypes.Score, 0, true);
        _orbitManager.enabled = false;
        UIManager.Instance.ShowScreen(ScreenTypes.MainMenu);
    }
    private void PausePressed()
    {
        _orbitManager.Pause(true);
        Time.timeScale = 0;
        UIManager.Instance.ShowPopup(PopupTypes.Pause);
    }
}
