using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Serializer
{
    public static void SaveGame(GameManager progress)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.sv";
        
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(progress);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadProgress()
    {
        string path = Application.persistentDataPath + "/save.sv";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();
            Debug.Log("Data loaded Succesfully");

            return data;
        }
        else
        {
            Debug.Log("Save file is not found at: " + path);
            return null;
        }
    }
}
