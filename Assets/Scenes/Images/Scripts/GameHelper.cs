using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public static bool scoreBool = true;
    int score = 0;
    public Text textScore;
    public GameObject textLose;
    public GameObject textEndGame;
    bool changeColour = true;
    float timerLose = 0.0f;
    public float setTimeToLose = 5f;
    void Start()
    {
        InvokeRepeating("Score", 1f, 1f);
        InvokeRepeating("TextColour", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        TextScore();
        Lose();
        QuitGame();
        ReloadGame();
    }

    void Score()
    {
        if(scoreBool)
        {
            score++;
        }
    }

    void TextScore()
    {
        textScore.text = "Punkty " + score + " !!!";
    }
    void TextColour()
    {
        if(changeColour)
        {
            textScore.color = Color.black;
            textLose.GetComponent<Text>().color = Color.black;
        }
        else
        {
            textScore.color = Color.red;
            textLose.GetComponent<Text>().color = Color.red;
        }
        changeColour = !changeColour;
    }

    void Lose()
    {
        if (scoreBool == false)
        {
            timerLose += Time.deltaTime;
            textLose.SetActive(true);
            textLose.GetComponent<Text>().text = "Masz " + string.Format("{0:0.00}", setTimeToLose - timerLose) + " sekund!!!!";
            if(timerLose>= setTimeToLose)
            {
                Time.timeScale = 0;
                textEndGame.SetActive(true);
                textEndGame.GetComponent<Text>().text = "Koniec Gry Punkty - " + score;
            }
        }
        else
        {
            timerLose = 0;
            textLose.SetActive(false);
        }
    }

    void QuitGame()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void ReloadGame()
    {
        if(textEndGame.activeSelf && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
    }



}
