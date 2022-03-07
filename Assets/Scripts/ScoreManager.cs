using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string currentName;
    public string bestName;
    public int currentScore;
    public int bestScore;

    private string savePath;

    private void Start()
    {

    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Application.persistentDataPath + "/savefile.json";
        Debug.Log(savePath);
    }

    [System.Serializable]
    class SaveData
    {
        //public string currentName;
        public string bestName;
        //public int currentScore;
        public int bestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestName = bestName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(savePath, json);
        Debug.Log("Data Saved");
    }

    public void LoadScore()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.bestName;
            bestScore = data.bestScore;
            Debug.Log("Data Loaded");
        }
    }
}
