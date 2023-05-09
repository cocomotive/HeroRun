using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJson : MonoBehaviour
{
    [SerializeField] SaveData data;

    string path;

    private void Start()
    {
        path = Application.persistentDataPath + "/save.json";

        if (File.Exists(path))
        {
            LoadGame();
        }
        else
        {
            SaveGame();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DeleteSave();
        }
    }
    public void SaveGame()
    {
        string save = JsonUtility.ToJson(data);

        File.WriteAllText(path, save);
    }
    public void LoadGame()
    {
        string save = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(save, data);
    }
    public void DeleteSave()
    {
        data = new SaveData();
        SaveGame();
    }
}
