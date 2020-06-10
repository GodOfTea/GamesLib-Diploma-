using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollectionData
{
    public string collectionName;
    public int gamesInCollection;

    public string[] gamesTitle;
    public string[] gamesPlatform;
    public string[] gamesData;
    public string[] gamesGener1;
    public string[] gamesGener2;

    public float[] gamesRate;
    public string[] gamesUrl;
    public string[] gamesImageUrl;

    public CollectionData(CollectionController data)
    {
        collectionName = data.collectionName.text;
        gamesInCollection = data.copy.gamesCount;

        gamesTitle    = new string[gamesInCollection];
        gamesPlatform = new string[gamesInCollection];
        gamesData     = new string[gamesInCollection];
        gamesGener1   = new string[gamesInCollection];
        gamesGener2   = new string[gamesInCollection];
        gamesRate     = new float [gamesInCollection];
        gamesUrl      = new string[gamesInCollection];
        gamesImageUrl = new string[gamesInCollection];

        var games = data.copy.gamesInCollection;
        for (int i = 0; i < gamesInCollection; i++)
        {
            gamesTitle[i]    = games[i].title;
            gamesPlatform[i] = games[i].platform;
            gamesData[i]     = games[i].gameDate;
            gamesGener1[i]   = games[i].genre1;
            gamesGener2[i]   = games[i].genre2;
            gamesRate[i]     = games[i].tag;
            gamesUrl[i]      = games[i].gameUrl;
            gamesImageUrl[i] = games[i].imageUrl;
        }

    }
}
