using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SocialPlatforms.Impl;

public class Orbit_Manager : PlayerEditor
{
    [SerializeField] private TMP_Text gameScore;
    //PlayerMovement
    public float speed = -100;
    SpriteRenderer playerSprite;
    GameManager gameManager;
    //Instance
    public static Orbit_Manager inst;

    private bool _isPaused;

    public int currentScore = 0;
    #region Player
    private void Awake()
    {
        inst = this;
        playerSprite = GetComponent<SpriteRenderer>();
        CreatePool();
    }
    private void Start()
    {
        gameManager = GameManager.inst;
    }
    private void OnEnable()
    {
        StartCoroutine(Spawner());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    void Update()
    {
        if(_isPaused)
        {
            return;
        }
       transform.parent.transform.Rotate(0, 0, speed * Time.unscaledDeltaTime);
        if (Input.GetButtonDown("Fire1"))
        {
            Direction();
        }
    }

    public void Pause(bool isPaused)
    {
        _isPaused = isPaused;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            if (Device.generation.ToString().Contains("iPhone") && SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.Vibration) == 1)
            {
                Debug.Log("Vibro");
                Handheld.Vibrate();
            }
            RandomPointPosition();
            if (Time.timeScale < 1.8f)
            {
                Time.timeScale += 0.05f;
            }
            currentScore++;
            ResourcesManager.Instance.ModifyResource(ResourceTypes.Score , 1);
            int score = ResourcesManager.Instance.GetResource(ResourceTypes.Score);
            gameScore.text = currentScore.ToString();
            if (SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.BestScore) < currentScore)
            {
                SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.BestScore, currentScore);
            }
            //gameManager.scoreManager.AddScore();
            //gameManager.coins += 1;
            //gameManager.soundManager.PlaySound(0);
        }
        if (collision.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            this.enabled = false;
            StopAllCoroutines();
            UIManager.Instance.ShowPopup(PopupTypes.Lose);
            //gameManager.Lose();
           // gameManager.scoreManager.SaveGameScore();
            //gameManager.soundManager.PlaySound(1);
        }
    }
    public void Direction()
    {
        speed = speed * -1;
        if (speed < 0)
        {
            //Right
            playerSprite.flipX = true;
        }
        else
        {
            //Left
            playerSprite.flipX = false;
        }
    }
    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Spawner
    //Spawn
    public
    GameObject enemy,point;
    GameObject[] enemies;
    public IEnumerator Spawner()
    {
        while (true)
        {
            GameObject e = GetEnemy();
            e.transform.position = Vector2.zero;
            e.transform.rotation = transform.rotation;
            if (speed < 0)
            {
                //Left
                e.transform.eulerAngles += new Vector3(0, 0, Random.Range(0, -90));
            }
            else
            {
                //Right
                e.transform.eulerAngles += new Vector3(0, 0, Random.Range(0, 90));
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    void RandomPointPosition()
    {
        float random = Random.Range(-360,360);
        point.transform.eulerAngles = new Vector3(0,0,random);
    }
    int index;
    GameObject GetEnemy()
    {
        index++;
        if (index >= enemies.Length) index = 0;
        return enemies[index];
    }
    void CreatePool()
    {
        int max = 10;
        enemies = new GameObject[max];
        RandomPointPosition();
        for(int i = 0; i < max; i++)
        {
            enemies[i] = Instantiate(enemy, Vector3.one*100, Quaternion.identity);
        }
    }
    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Virtual
    public override void Enable(bool enabled)
    {
        this.enabled = enabled;
    }
    public override void Reset()
    {
        transform.parent.rotation = Quaternion.identity;
        currentScore =  0;
    }
    #endregion
}