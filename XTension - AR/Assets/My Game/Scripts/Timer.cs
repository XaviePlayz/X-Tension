using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue;
    public Text timeText;
    public GameObject Victory;
    public GameObject Player;
    public GameObject Music;
    public GameObject SoundEffects;
    public GameObject VictoryMusic;
    public GameObject GameOverScreenText;

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        if (timeValue == 0)
        {
            Music.SetActive(false);
            SoundEffects.SetActive(false);
            Player.SetActive(false);
            Victory.SetActive(true);
            VictoryMusic.SetActive(true);
        }
        DisplayTime(timeValue);

        if (GameOverScreenText.activeInHierarchy)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
