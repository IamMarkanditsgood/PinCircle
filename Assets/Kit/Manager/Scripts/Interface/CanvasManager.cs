using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


#region Canvas Manager
public class CanvasManager : MonoBehaviour
{
    [HideInInspector] public Canvas[] canvas;
    int currentEnabled = 0;
    public static CanvasManager inst;
    //UI Events
    void Awake()
    {
        inst = this;
    }
    private void Start()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("BackButton");
        Button[] b = new Button[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            b[i] = buttons[i].GetComponent<Button>();
            b[i].onClick.AddListener(() => { OpenMainMenu(); });
        }
    }

    public void ShowCanvas(int i)
    {
        if (canvas[i].isActiveAndEnabled)
        {
            canvas[i].enabled = false;
        }
        else
        {
            canvas[i].enabled = true;
            currentEnabled = i;
        }
    }
 public void OpenMainMenu()
    {
        ShowCanvas(currentEnabled);
        if (canvas[0].isActiveAndEnabled) return; 
        ShowCanvas(0);
    }
    public void OpenUrls(string url)
    {
        Application.OpenURL(url);
    }
    //public void Rate(int i)
    //{
    //    if (i == 0)
    //    {
    //        StartCoroutine(OpenRate());
    //    }
    //    else if (i == 1)
    //    {
    //        PlayerPrefs.SetInt("rate", 1);
    //    }
    //    else
    //    {
    //        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Puszkarek.Deflect");
    //        PlayerPrefs.SetInt("rate", 1);
    //    }
    //    ShowCanvas(5);
    //}
    //IEnumerator OpenRate()
    //{
    //    if (PlayerPrefs.GetInt("rate") == 1)
    //    {
    //        yield break;
    //    }
    //    yield return new WaitForSeconds(60);
    //    yield return new WaitUntil(() => canvas[0].enabled == true);
    //    ShowCanvas(5);
    //}
}
#endregion
#region Editor Settings
#if UNITY_EDITOR
[CustomEditor(typeof(CanvasManager))]
public class CanvasManager_Editor : Editor
{
    string[] tags = { "MainMenu", "Restart", "Shopping"};
    public override void OnInspectorGUI()
    {
        SetSettings();
    }
    public void SetSettings()
    {
        DrawDefaultInspector(); // for non-HideInInspector fields
        CanvasManager script = (CanvasManager)target;

        script.canvas = new Canvas[3];
        int i;
        for (i = 0; i < script.canvas.Length; i++)
        {
            GameObject obj = GameObject.FindGameObjectWithTag(tags[i]);
            script.canvas[i] = obj.GetComponent<Canvas>();
        }

    }

}
#endif
#endregion

