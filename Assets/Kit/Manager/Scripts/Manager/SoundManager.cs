using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    Image buttonImage;
    public Sprite[] buttonSprites;
    public AudioClip[] sounds;
    public static SoundManager inst;
    void Awake()
    {
        inst = this;
        GameObject buttonObject = GameObject.FindGameObjectWithTag("soundButton");
        buttonImage = buttonObject.GetComponent<Image>();
        Button b = buttonObject.GetComponent<Button>();
        b.onClick.AddListener(() => { ToggleAudio(); });
        SetToggle();
    }
    void SetToggle()
    {
        if (AudioListener.volume == 1)
        {
            buttonImage.sprite = buttonSprites[1];
        }
        else { buttonImage.sprite = buttonSprites[0]; }
    }
    public void ToggleAudio()
    {
        if (AudioListener.volume == 1) { AudioListener.volume = 0; }
        else { AudioListener.volume = 1; }
        SetToggle();
    }
    public void PlaySound(int i)
    {
        AudioSource.PlayClipAtPoint(sounds[i], Vector3.zero);
    }
}
