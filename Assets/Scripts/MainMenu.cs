using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string sceneName;

    public string Creditscene;

    public void PlayGmae()
    {
        PlayerData.isGameStarted = true;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Game Loaded");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene(Creditscene);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
