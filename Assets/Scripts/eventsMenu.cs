using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class eventsMenu : MonoBehaviour
{
    public InputField name;
    public Text warn;
    public static string playerName;
    public void begin()
    {
        if (name.text == "")
            warn.gameObject.SetActive(true);
        else
        {
            playerName = name.text;
            SceneManager.LoadScene("game");
        }
    }
    public void exit()
    {
        Application.Quit();
    }

    
}
