using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    //Theme
    [Serializable]
    public class Theme
    {
        public
        Color
            backgroundColor,
            fontColor,
            spriteColor;
    }
    public Theme[] themes;
    public Material
        backgroundMat,
        fontMat,
        spriteMat;
    [HideInInspector] public int i;
    public static ThemeManager inst;
    private void Awake()
    {
        inst = this;
        RandomTheme();
    }
    public void RandomTheme()
    {
        /*i = UnityEngine.Random.Range
            (0, themes.Length);
        SetTheme();*/
    }
    void SetTheme()
    {
        backgroundMat.SetColor("_Color", themes[i].backgroundColor);
        fontMat.SetColor("_Color", themes[i].fontColor);
        spriteMat.SetColor("_Color",themes[i].spriteColor);
    }
    public void OnLose()
    {
        backgroundMat.SetColor("_Color", Color.gray);
    }

}