using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class TextFade : MonoBehaviour
{
    [SerializeField]
    float 
        time = 0.5f;
    [HideInInspector]
    public 
        Text 
        text;
    [SerializeField]
    Color 
        defaultColor = Color.white,
        targetColor = Color.white;
    void Update()
    {
        float t  = Mathf.PingPong(Time.time * time, 1.0f);
        text.color = Color.Lerp(defaultColor, targetColor, t);
    }
}
#region Editor Settings
#if UNITY_EDITOR
[CustomEditor(typeof(TextFade))]
public class Fade_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TextFade script = (TextFade)target;
        script.text = script.GetComponent<Text>();

    }
}
#endif
#endregion
