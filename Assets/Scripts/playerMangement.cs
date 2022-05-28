using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMangement : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject gameOn;
    public Text coins;
    public Text score;
    public Text name;
    public Text coinsGameOver;
    public Text scoreGameOver;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        gameOn.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
       
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOn.SetActive(false);
            coinsGameOver.text = coins.text;
            scoreGameOver.text = score.text;
            name.text = eventsMenu.playerName;
        }else
        {
            coins.text = Movement.CoinsCounter.ToString();

            score.text = Movement.ScoreCounter.ToString();
        }

    }
}
