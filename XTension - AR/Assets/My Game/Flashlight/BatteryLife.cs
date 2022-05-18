using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryLife : MonoBehaviour
{
    public Timer time;
    public RandomLevelGenerator rndLevel;

    public GameObject FlashLight_1;
    public GameObject FlashLight_2;
    public GameObject FlashLight_3;

    public AudioSource FlashlightON;
    public AudioSource FlashlightOFF;

    public float timeDelay;
    public bool LightsOut;
    public Text lightsText;

    public void Awake()
    {
        lightsText.text = "";
        StartCoroutine(LifeControl());
    }

    public void Update()
    {
        if (rndLevel.generator == 1)
        {
            if (LightsOut == true)
            {
                FlashLight_1.SetActive(false);
            }
            else
            {
                FlashLight_1.SetActive(true);
            }
        }
        else if (rndLevel.generator == 2)
        {
            if (LightsOut == true)
            {
                FlashLight_2.SetActive(false);
            }
            else
            {
                FlashLight_2.SetActive(true);
            }
        }
        else if (rndLevel.generator == 3)
        {
            if (LightsOut == true)
            {
                FlashLight_3.SetActive(false);
            }
            else
            {
                FlashLight_3.SetActive(true);
            }
        }
    }
        IEnumerator LifeControl()
    {
        timeDelay = Random.Range(15f, 20f);
        yield return new WaitForSeconds(timeDelay);
        FlashlightOFF.Play();
        LightsOut = true;
        lightsText.text = "Refreshing Batteries...";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries..";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries.";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries...";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries..";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries.";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries...";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries..";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries.";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries...";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries..";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries.";
        yield return new WaitForSeconds(0.4f);
        lightsText.text = "Refreshing Batteries";
        yield return new WaitForSeconds(0.4f);

        lightsText.text = "Batteries Refreshed";
        FlashlightON.Play();
        LightsOut = false;
        yield return new WaitForSeconds(1.5f);
        lightsText.text = "";
        if (time.timeValue > 0)
        {
            StartCoroutine(LifeControl());
        }
    }
}
