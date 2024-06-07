using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string playerName;
    public string recordPlayer;
    public int recordScore;

    private void Awake()
    {
        // This pattern is called a singleton.
        // You use it to ensure that only a single instance of the MainManager can ever exist, so it acts as a central point of access.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadRecord();
    }

    [System.Serializable]
    class SaveData
    {
        public string recordPlayer;
        public int recordScore;
    }

    public void SaveRecord()
    {
        recordPlayer = playerName;

        SaveData data = new SaveData();
        data.recordPlayer = playerName;
        data.recordScore = recordScore;

        string json = JsonUtility.ToJson(data);

        Debug.Log("Saving record at: " + Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            recordPlayer = data.recordPlayer;
            recordScore = data.recordScore;
        }
        else {
            recordPlayer = "Player";
            recordScore = 0;
        }
    }
}
