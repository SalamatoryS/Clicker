using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataBetweenScenes : MonoBehaviour
{
    public static DataBetweenScenes Instance;
    public string userName;

    public int maxScore;
    public string maxScoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveUser(int maxScore)
    {
        SaveData saveUser = new SaveData();
        saveUser.name = userName;
        saveUser.score = maxScore;

        string json = JsonUtility.ToJson(saveUser);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadUser()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData loadUser = JsonUtility.FromJson<SaveData>(json);

            maxScoreName = loadUser.name;
            maxScore = loadUser.score;
        }
    }
    public void DeleteResult()
    {
        SaveData deleteData = new SaveData();
        deleteData.name = "";
        deleteData.score = 0;
        string json = JsonUtility.ToJson(deleteData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}

