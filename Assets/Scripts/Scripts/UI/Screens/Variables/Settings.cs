using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : BasicScreen
{
    [SerializeField] private Button HomeButton;
    [SerializeField] private Button VibrationButton;
    [SerializeField] private Button RateUsButton;
    [SerializeField] private Button WriteUsButton;

    [SerializeField] private TMP_Text _score;

    [SerializeField] private Sprite _off;
    [SerializeField] private Sprite _on;

    public string emailAddress = "example@example.com";
    public string subject = "Your Subject Here";
    public string body = "Your message body here";

    private TextManager _textManager = new TextManager();

    private void Start()
    {
        if (!SaveManager.PlayerPrefs.IsSaved(GameSaveKeys.Vibration))
        {
            SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.Vibration, 1);
        }

        HomeButton.onClick.AddListener(Home);
        VibrationButton.onClick.AddListener(Vibration);
        RateUsButton.onClick.AddListener(RateUs);
        WriteUsButton.onClick.AddListener(WriteUs);
    }

    private void OnDestroy()
    {
        HomeButton.onClick.RemoveListener(Home);
        VibrationButton.onClick.RemoveListener(Vibration);
        RateUsButton.onClick.RemoveListener(RateUs);
        WriteUsButton.onClick.RemoveListener(WriteUs);
    }

    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
        SetText();

        int vibrationState = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.Vibration);
        switch (vibrationState)
        {
            case 0:
                VibrationButton.GetComponent<Image>().sprite = _off;
                break;
            case 1:
                VibrationButton.GetComponent<Image>().sprite = _on;
                break;
        }
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

    private void Vibration()
    {
        int vibrationState = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.Vibration);
        switch(vibrationState)
        {
            case 0:
                SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.Vibration, 1);
                VibrationButton.GetComponent<Image>().sprite = _on;
                break;
            case 1:
                SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.Vibration, 0);
                VibrationButton.GetComponent<Image>().sprite = _off;
                break;
        }
    }
    private void RateUs()
    {
#if UNITY_IPHONE
        Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_APP_ID");
#else
            Debug.Log("Rate Us functionality is only supported on iOS.");
#endif
    }

    private void WriteUs()
    {
        OpenEmailClient();
    }
    void OpenEmailClient()
    {
        string emailUrl = string.Format("mailto:{0}?subject={1}&body={2}", emailAddress, EscapeURL(subject), EscapeURL(body));
        Application.OpenURL(emailUrl);
    }

    string EscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }
}