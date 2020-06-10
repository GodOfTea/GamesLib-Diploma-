using UnityEngine;

[System.Serializable]
public class CollectionsNameData
{
    public string[] names;

    public CollectionsNameData(MyCollectionsPanelController data)
    {
        names = new string[data.myCollection.Count];

        for (int i = 0; i < data.myCollection.Count; i++)
        {
            names[i] = data.myCollection[i].collectionName.text;
        }
    }
}
