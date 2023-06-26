using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJson : MonoBehaviour
{
    [SerializeField] CurrencyManager data;


    public static SaveJson instance;

    public string path;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
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
    public void SaveGame()
    {
        string save = JsonUtility.ToJson(data);

        File.WriteAllText(path, save);

        Debug.Log("SAVE");
    }
    public void LoadGame()
    {
        string save = File.ReadAllText(path);

        JsonUtility.FromJsonOverwrite(save, data);

        Debug.Log("LOAD");
    }
    public void DeleteSave()
    {
        data = new CurrencyManager();
        SaveGame();
    }
}
