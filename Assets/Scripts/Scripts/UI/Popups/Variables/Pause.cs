using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pause : BasicPopup
{

    [SerializeField] private TMP_Text _score;
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _pauseButton;

    [SerializeField] private Orbit_Manager _orbitManager;

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
    public override void ResetPopup()
    {
    }

    public override void SetPopup()
    {
        _score.text = ResourcesManager.Instance.GetResource(ResourceTypes.Score).ToString();
    }

    private void HomePressed()
    {
        ResourcesManager.Instance.ModifyResource(ResourceTypes.Score, 0, true);
        _orbitManager.enabled = false;
        UIManager.Instance.ShowScreen(ScreenTypes.MainMenu);
    }
    private void PausePressed()
    {
        _orbitManager.Pause(false);
        Time.timeScale = 1;
        UIManager.Instance.HidePopup(PopupTypes.Pause);
    }

}
