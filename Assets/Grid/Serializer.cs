using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class Serializer
{

    //public static void SavePlayer(GameManager progress)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/TestBinary.test";
    //    FileStream stream = new FileStream(path, FileMode.Create);
    //    GridState data = new GridState(progress);

    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //}
    //public static GridState
    //Progress()
    //{
    //    string path = Application.persistentDataPath + "/TestBinary.test";
    //    if (File.Exists(path)) 
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter;
    //        FileStream stream = new FileStream(path,FileMode.Open);
    //        GridState data = formatter.Deserialize(stream) as GridState;
    //        stream.Close();
    //        Debug.Log("Data loaded success");
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.Log("No save file found");
    //        return null;
    //    }
    //}
}
