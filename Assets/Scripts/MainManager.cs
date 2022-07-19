using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameOverText;
    public GameObject highscoreScreen;
    public TMP_InputField inputField;
    public Material[] materials;
    public GameObject paddle;

    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    int highScore;
    string playerName;


    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        UpdateHighScore();
        paddle.GetComponent<MeshRenderer>().material = materials[GameManager.Instance.matNum];
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    void UpdateHighScore()
    {
        highScore = GameManager.Instance.HighScore;
        string highScorePlayerName = GameManager.Instance.highScoreName;
        HighScoreText.text = "High Score : " + highScorePlayerName + ": " + highScore;
    }

    public void InputHighestName()
    {
        playerName = inputField.text;
        if (m_Points == highScore)
        {
            GameManager.Instance.highScoreName = playerName;
        }
        else if (m_Points == GameManager.Instance.secondHighScore)
        {
            GameManager.Instance.secondhighScoreName = playerName;
        }
        else if (m_Points == GameManager.Instance.thirdHighScore)
        {
            GameManager.Instance.thirdHighScoreName = playerName;
        }

        GameManager.Instance.SaveHighScore();
        SceneManager.LoadScene(2);
    }


    public void GameOver()
    {
        
        if (m_Points > highScore)
        {
            highscoreScreen.SetActive(true);
            GameManager.Instance.HighScore = m_Points;
        }
        else if (m_Points > GameManager.Instance.secondHighScore)
        {
            highscoreScreen.SetActive(true);
            GameManager.Instance.secondHighScore = m_Points;
        }
        else if (m_Points > GameManager.Instance.thirdHighScore)
        {
            highscoreScreen.SetActive(true);
            GameManager.Instance.thirdHighScore = m_Points;
        }
        else
        {
            m_GameOver = true;
            GameOverText.SetActive(true);
        }
        

    }
}
