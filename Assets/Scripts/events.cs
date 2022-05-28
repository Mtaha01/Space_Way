using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class events : MonoBehaviour
{
    public Text playerName;
    public void replay()
    { 
            SceneManager.LoadScene("game");
    }
    public void exit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main start");
    }
}
