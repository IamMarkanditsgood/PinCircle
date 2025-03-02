using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : BasicScreen
{
    [SerializeField] private Button HomeButton;
    [SerializeField] private Button _taskReward;

    [SerializeField] private Sprite _defaultTaskButton;
    [SerializeField] private Sprite _doneTaskButton;
    [SerializeField] private Sprite _claimedTaskButton;

    [SerializeField] private TMP_Text _score;

    private TextManager _textManager = new TextManager();

    private void Start()
    {
        _taskReward.onClick.AddListener(TaskButtonPressed);
        HomeButton.onClick.AddListener(Home);
    }

    private void OnDestroy()
    {
        _taskReward.onClick.RemoveListener(TaskButtonPressed);
        HomeButton.onClick.RemoveListener(Home);
    }

    public override void ResetScreen()
    {
        _taskReward.interactable = false;
        _taskReward.GetComponent<Image>().sprite = _defaultTaskButton;
    }

    public override void SetScreen()
    {
        SetText();
        SetTasks();
    }

    private void SetText()
    {
        int coins = ResourcesManager.Instance.GetResource(ResourceTypes.Score);
        _textManager.SetText(coins, _score, true);


    }

    private void SetTasks()
    {
        int firstTask = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.FirstTask);

        if (firstTask == 0)
        {
            _taskReward.interactable = false;
            _taskReward.GetComponent<Image>().sprite = _defaultTaskButton;
        }
        else if(firstTask == 1)
        {
            _taskReward.interactable = true;
            _taskReward.GetComponent<Image>().sprite = _doneTaskButton;
        }
        else
        {
            _taskReward.interactable = false;
            _taskReward.GetComponent<Image>().sprite = _claimedTaskButton;
        }
    }

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.MainMenu);
    }
    private void TaskButtonPressed()
    {
        SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.FirstTask, 2);
        ResourcesManager.Instance.ModifyResource(ResourceTypes.Score, 100); 
        _taskReward.interactable = false;
        _taskReward.GetComponent<Image>().sprite = _claimedTaskButton;
        SetText();
    }
}
