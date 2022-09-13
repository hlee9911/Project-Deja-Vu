using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerDisplay : MonoBehaviour
{

    public TextMeshProUGUI countTimer;
    public string mainMenu;
    public string playAgain;

    public void PlayAgain()
    {
        PlayerData.isGameStarted = true;
        SceneManager.LoadScene(playAgain);
    }

    public void BacktoMainMenu()
    {
        PlayerData.isGameStarted = false;
        SceneManager.LoadScene(mainMenu);
    }

    // Start is called before the first frame update
    void Start()
    {
        TimerController.timerGoing = false;
        TimerController.timePlaying = TimeSpan.FromSeconds(TimerController.elapsedTime);
        string TimerPlayingstr = "YOU TOOK : " + TimerController.timePlaying.ToString("mm':'ss'.'ff");
        countTimer.text = TimerPlayingstr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
