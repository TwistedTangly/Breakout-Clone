using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUI : MonoBehaviour
{

    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject settingsScreen;

    private void Start()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void GameStart()
    {
        GameManager.Instance.SaveHighScore();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        if(EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }

    public void RedButton()
    {
        GameManager.Instance.matNum = 0;
    }

    public void GreenButton()
    {
        GameManager.Instance.matNum = 1;
    }

    public void YellowButton()
    {
        GameManager.Instance.matNum = 2;
    }

    public void BlueButton()
    {
        GameManager.Instance.matNum = 3;
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void MainMenuScreen()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void HighScore()
    {
        SceneManager.LoadScene(2);
    }

}
