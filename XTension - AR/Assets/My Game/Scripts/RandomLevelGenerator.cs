using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLevelGenerator : MonoBehaviour
{
    public Text generatingText;
    public float loading;
    public bool hasLoaded;
    public float generator;

    public Transform Player;
    public Transform TeleportGoal2;
    public Transform TeleportGoal3;

    public GameObject loadScreen;

    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;

    public void Awake()
    {
        loadScreen.SetActive(true);
        generator = Random.Range(1, 4);
    }

    public void Start()
    {
        Player = GameObject.Find("Player").transform;
        Level2.SetActive(false);
        hasLoaded = false;
        StartCoroutine(Generating());
    }

    IEnumerator Generating()
    {
        if (loading < 3)
        {
            generatingText.text = string.Format("LOADING...");
            yield return new WaitForSeconds(0.4f);
            generatingText.text = string.Format("LOADING..");
            yield return new WaitForSeconds(0.4f);
            generatingText.text = string.Format("LOADING.");
            yield return new WaitForSeconds(0.4f);
            generatingText.text = string.Format("LOADING");
            yield return new WaitForSeconds(0.4f);
            StartCoroutine(Generating());
            loading++;

        }
        if (loading == 3)
        {
            if (hasLoaded == false)
            {
                hasLoaded = true;
                if (generator == 1)
                {
                    Level2.SetActive(false);
                    Level3.SetActive(false);
                    Level1.SetActive(true);

                }
                else if (generator == 2)
                {
                    Level1.SetActive(false);
                    Level3.SetActive(false);
                    Level2.SetActive(true);
                    Player.position = TeleportGoal2.position;
                }
                else if (generator == 3)
                {
                    Level1.SetActive(false);
                    Level2.SetActive(false);
                    Level3.SetActive(true);
                    Player.position = TeleportGoal3.position;
                }
                loadScreen.SetActive(false);
            }
        }
    }
}