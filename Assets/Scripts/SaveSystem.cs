using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void Save(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static PlayerData Load()
    {
        if(!File.Exists(GetPath()))
        {
            PlayerData emptyData = new PlayerData();
            Save(emptyData);
            return emptyData;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        PlayerData data = formatter.Deserialize(fs) as PlayerData;
        fs.Close();

        return data;
    }
    private static string GetPath()
    {
        return Application.persistentDataPath + "/data.game";
    }
}
