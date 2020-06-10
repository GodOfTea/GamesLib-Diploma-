using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveCollection(CollectionController data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + data.collectionName.text + "_collection.gg";
        FileStream stream = new FileStream(path, FileMode.Create);

        CollectionData collectionData = new CollectionData(data);

        formatter.Serialize(stream, collectionData);
        stream.Close();
    }

    public static void SaveNames(MyCollectionsPanelController data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/names.gg";
        FileStream stream = new FileStream(path, FileMode.Create);

        CollectionsNameData namesData = new CollectionsNameData(data);

        formatter.Serialize(stream, namesData);
        stream.Close();
    }

    public static CollectionData LoadCollection(string collectionName)
    {
        string path = Application.persistentDataPath + "/" + collectionName + "_collection.gg";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CollectionData data = formatter.Deserialize(stream) as CollectionData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Don`t find names.gg file");
            return null;
        }
    }

    public static CollectionsNameData LoadNames()
    {
        string path = Application.persistentDataPath + "/names.gg";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CollectionsNameData data = formatter.Deserialize(stream) as CollectionsNameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Don`t find names.gg file");
            return null;
        }
    }
}
