using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveStats : MonoBehaviour
{
    public static void Save(PlayerStats playerStats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "stats.fart";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(playerStats);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "stats.fart";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
