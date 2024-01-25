using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public GameObject gameOverManu;
    public TextMeshProUGUI Timer;
    public GameObject Player;

    public float timeRemaining = 5;


    void Start()
    {
        UpdateTime(timeRemaining);
        gameOverManu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTime(timeRemaining);
        }
        else
        {
            UpdateTime(0);
            GameOver();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<FirstPersonController>().enabled = false;
        }


    }
    public void UpdateTime(float timeLeft)
    {
        Timer.text = "Time remaining : " + timeLeft;
    }
    public void GameOver()
    {
        gameOverManu.gameObject.SetActive(true);
    }
}