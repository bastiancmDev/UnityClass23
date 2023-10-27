using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinaryFileConverter 
{
    public bool SaveDataOnBinary(object data, string path)
    {
        try
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Create(path);
            binaryFormatter.Serialize(fileStream, data);
            fileStream.Close();
            return true;
        }
        catch(Exception e)
        {
            Debug.LogError("Error create file ");
        }

        return false;
    }


    public object LoadDataBinary(string path)
    {
        if (FileUtility.FileExist(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(path,FileMode.Open);

            object LoadedData = binaryFormatter.Deserialize(fileStream);
            return LoadedData;
        }
        else
        {
            Debug.LogError("Error Loaded file ");
            return null;
        }
    }
}
