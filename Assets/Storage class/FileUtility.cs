using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileUtility
{

    public static bool FileExist(string path)
    {
        return File.Exists(path);       
    }


    public static bool SaveDataInFile(string data, string path)
    {              
        try
        {
            File.WriteAllText(path, data);
            Debug.Log("Data Saved Succes" + data + "on " + path);
            return true;
        }catch(Exception e)
        {
            Debug.LogError("Error on save data " + e.Message);
            return false;
        }        
    }


    public static string LoadFile(string path)
    {
        if (FileExist(path))
        {
            string data = File.ReadAllText(path);
            return data;
        }
        else
        {
            Debug.LogError("path no existe");
        }
        return "";
    }

}
    

