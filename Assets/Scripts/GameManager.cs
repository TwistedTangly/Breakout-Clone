using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int HighScore;
    public string highScoreName;
    public int secondHighScore;
    public string secondhighScoreName;
    public int thirdHighScore;
    public string thirdHighScoreName;

    public int matNum;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        GetHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string highScoreName;
        public int secondHighScore;
        public string secondhighScoreName;
        public int thirdHighScore;
        public string thirdHighScoreName;

        public int matNum;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.highScoreName = highScoreName;

        data.secondHighScore = secondHighScore;
        data.secondhighScoreName = secondhighScoreName;

        data.thirdHighScore = thirdHighScore;
        data.thirdHighScoreName = thirdHighScoreName;


        data.matNum = matNum;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void GetHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            highScoreName = data.highScoreName;
            secondHighScore = data.secondHighScore;
            secondhighScoreName = data.secondhighScoreName;
            thirdHighScore = data.thirdHighScore;
            thirdHighScoreName = data.thirdHighScoreName;

            matNum = data.matNum;
        }
    }


}
