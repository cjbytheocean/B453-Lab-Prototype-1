using UnityEngine;
using System.IO;

public class JSONManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
       public float highScore = 0f; 
    }

    [System.Serializable]
    public class AllData
    {
        public PlayerData playerData;
    }

    public static JSONManager instance;
    private string filePath = Application.dataPath + "/JSONData.json";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        string JSONOutput = JsonUtility.ToJson(GetData());
        File.WriteAllText(filePath, JSONOutput);
    }

    public AllData LoadData()
    {
        string readJSON;
        if (!File.Exists(filePath))
        {
            DefaultJSON();
        }
        readJSON = File.ReadAllText(filePath);
        AllData data = JsonUtility.FromJson<AllData>(readJSON);
        return data;
    }

    public AllData GetData()
    {
        AllData data = new AllData();

        //data.playerData = GameManager.instance.JSONGetPlayerData();

        return data;
    }

    void DefaultJSON()
    {
        AllData data = new AllData();

        data.playerData = new PlayerData();

        string outputJSON = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, outputJSON);
    }    
}