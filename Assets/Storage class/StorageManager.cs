using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{

    public static StorageManager Instance;
    public string BasePath;

    private BinaryFileConverter binaryFileConverter;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void Init()
    {
        binaryFileConverter = new BinaryFileConverter();
        BasePath = Application.persistentDataPath +"/";
    }


    private void Start()
    {
        LoadPlayerDaraFromBinary();
    }


    public void TestSaveData()
    {
        PlayerDataModel dataPlayer = new();
        dataPlayer.id = 1;
        dataPlayer.Name = "Nicolas Migues";
        dataPlayer.Items = new ItemModel[] { new ItemModel{ id = 1, count = 30 }, new ItemModel { id = 2, count = 20 }, new ItemModel { id = 3, count = 10 } };
        string dataInJson = JsonUtility.ToJson(dataPlayer);
        FileUtility.SaveDataInFile(dataInJson, BasePath + "PlayerData.json");        
    }


    public PlayerDataModel LoadPlayerData()
    {
        string dataPath = BasePath + "PlayerData.json";
        if (FileUtility.FileExist(dataPath))
        {
            string jsonData = FileUtility.LoadFile(dataPath);
            PlayerDataModel playerData = JsonUtility.FromJson<PlayerDataModel>(jsonData);        
            
            return playerData;
        }
        else
        {
            Debug.LogError(" file on dataPath doesnt exist");
            return PlayerData.GetDefault();
        }
    }


    public void SaveDataOnBinary()
    {
        var playerData = LoadPlayerData();
        binaryFileConverter.SaveDataOnBinary(playerData, BasePath + "BinaryData.dat");
    }

    public PlayerDataModel LoadPlayerDaraFromBinary()
    {
        var plaDataModel = (binaryFileConverter.LoadDataBinary(BasePath + "BinaryData.dat")) as PlayerDataModel;
        return plaDataModel;
    }

    


}
