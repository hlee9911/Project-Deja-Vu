using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public string mainMenu;
    public string playAgain;

    public void PlayAgain()
    {
        SceneManager.LoadScene(playAgain);
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
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
