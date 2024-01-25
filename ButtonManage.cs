using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class ButtonManage : MonoBehaviour
{
    public GameObject UIRule;
    public AudioSource ClickSound;


    void Start()
    {
        UIRule.gameObject.SetActive(false);
    }

    public void StartButton()
    {
        HowtoPlay();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void HowtoPlay()
    {
        UIRule.gameObject.SetActive(true);
    }


    //Sound
    public void PlaySoundEffect()
    {
        ClickSound.Play();
    }

}