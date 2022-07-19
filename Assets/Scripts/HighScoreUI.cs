using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highestScoreText;
    [SerializeField] TextMeshProUGUI SecondHighestScoreText;
    [SerializeField] TextMeshProUGUI thirdHighestScoreText;
    void Start()
    {
        highestScoreText.text = GameManager.Instance.highScoreName + ": " + GameManager.Instance.HighScore;
        SecondHighestScoreText.text = GameManager.Instance.secondhighScoreName + ": " + GameManager.Instance.secondHighScore;
        thirdHighestScoreText.text = GameManager.Instance.thirdHighScoreName + ": " + GameManager.Instance.thirdHighScore;
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }
}
