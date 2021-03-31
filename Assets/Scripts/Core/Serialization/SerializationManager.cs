using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SerializationManager
{
    public static bool Save(string saveName, object saveData)
    {
        //Creates the BinaryFormatter class we need to Serialize/Deserialize
        BinaryFormatter formatter = GetBinaryFormatter();

        //Checks if saves directory exists. IF not, creates it
        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        //Creates the Save file at the set path
        FileStream file = File.Create(path);

        //Takes the new empty save file and appends saveData to it then Serializes (or converts to 1s & 0s)  
        formatter.Serialize(file, saveData);

        file.Close();

        return true;

    }


    public static object Load(string path)
    {
        //If a file does not exist at the given path, return null
        if (!File.Exists(path))
        {
            return null;
        }

        //Again gives us the BinaryFormatter Class access
        BinaryFormatter formatter = GetBinaryFormatter();


        //Will set the file at the given path to FileMode.Open
        FileStream file = File.Open(path, FileMode.Open);


        //Will Try to append the deserialized data to save obj
        //Then will Close
        //and return the save object (the non-binary readable game data)
        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        //If FileStream file = File.Open(path, FileMode.Open); tries to open
        //An invalid file, it will log an error and return null.
        //Maybe save was corrupted, deleted
        catch
        {
            Debug.LogErrorFormat("Failed to load file at ", path);
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
 
        return formatter;
    }
    

    public static bool VerifyExistingData(int saveSlot)
    {
        
        string path = Application.persistentDataPath + "/saves/SaveDataSlot_" + saveSlot + ".save";
        if (File.Exists(path))
        {
            return true;
        }

        return false;
    }

}
