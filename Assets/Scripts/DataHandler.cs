using UnityEngine;
using System.IO;

public class DataHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static DataHandler Instance;
    public string playerName;
    public string bestPlayerName;
    public int playerScore;
    public int bestPlayerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayer();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;

    }

    public void SavePlayer()
    {
        Debug.Log("player: " + playerScore + ", bestPlayer: " + bestPlayerScore);
        if (playerScore > bestPlayerScore)
        {
            SaveData data = new SaveData();

            bestPlayerScore = playerScore;
            bestPlayerName = playerName;
            data.playerName = playerName;
            data.playerScore = playerScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            Debug.Log("Saving data >>>" + Application.persistentDataPath);
        }

    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log("Loading data <<<" + Application.persistentDataPath);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            bestPlayerScore = data.playerScore;
        }
    }

}