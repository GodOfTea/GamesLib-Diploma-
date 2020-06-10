using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameCollection
{
    public string collectionName;
    
    public int gamesCount;

    public List<Games> gamesInCollection;

    public List<Sprite> gameIcons;
}
