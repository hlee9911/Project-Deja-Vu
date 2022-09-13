using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{

    public GameObject tutorialText;

    public static TimerController instance;

    public TextMeshProUGUI timeCounter;

    public static TimeSpan timePlaying;
    public static bool timerGoing = false;

    public static float elapsedTime = 0;

    public static bool TutorialDisplayed = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerData.isGameStarted)
        {
            elapsedTime = 0f;
            PlayerData.isGameStarted = false;
        }
        DontDestroyOnLoad(timeCounter);
        timerGoing = true;
    }

    void DisableText()
    {
        tutorialText.SetActive(false);
    }

    private void Update()
    {
        if (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string TimerPlayingstr = "Time : " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = TimerPlayingstr;
        }
    }

    /*
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }
    */

    public void EndTimer()
    {
        timerGoing = false;
    }

    /*
    private IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string TimerPlayingstr = "Time : " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = TimerPlayingstr;
        }

        yield return null;
    }
    */
}
