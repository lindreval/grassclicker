using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public GameData gameData = new GameData();

    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/save.json";
            LoadGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            gameData = new GameData(); // create new if no save
        }
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }

    public void ResetGame()
    {
        // Reset the in-memory data
        gameData = new GameData(); // This assumes GameData has default values in its constructor

        // Optionally, reset any other runtime variables here too
        // e.g., AudioManager.Instance.volume = gameData.volume;

        // Clear PlayerPrefs if you use them
        PlayerPrefs.DeleteAll();

        // Save the reset state immediately
        SaveGame();
    }
}
