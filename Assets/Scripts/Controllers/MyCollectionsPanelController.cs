using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MyCollectionsPanelController : MonoBehaviour
{
    [Title("Static Value"), ShowInInspector]
    public static CollectionController OpenedCollection;

    [Title("Links")]
    [SerializeField] private UIGrid grid;
    [SerializeField] private GameObject searchPanel;

    [Title("Prefabs")]
    [SerializeField] private GameObject addCollectionPrefab;
    [SerializeField] private GameObject gameCollectionPrefab;

    [Title("My Collection")]
    public List<CollectionController> myCollection;

    private GameCollection collection; /* для загрузки */
    private CollectionController controller;
    private Sprite icon;

    private void Awake()
    {

        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        Debug.Log("Load");
        CollectionsNameData namesData = SaveSystem.LoadNames();

        for (int i = 0; i < namesData.names.Length; i++)
        {
            string collectionName = namesData.names[i];
            CollectionData data = SaveSystem.LoadCollection(collectionName);

            collection = new GameCollection();
            collection.gamesInCollection = new List<Games>();
            collection.collectionName = data.collectionName;
            collection.gamesCount = data.gamesInCollection;
            
            for (int j = 0; j < data.gamesInCollection; j++)
            {
                collection.gamesInCollection.Add(new Games{ /* Придумать как подгружать в icon <- imageUrl */
                    title    = data.gamesTitle[j],
                    genre1   = data.gamesGener1[j],
                    genre2   = data.gamesGener2[j],
                    platform = data.gamesPlatform[j],
                    gameDate = data.gamesData[j],
                    tag      = data.gamesRate[j],
                    imageUrl = data.gamesImageUrl[j],
                    gameUrl  = data.gamesUrl[j],
                });
                WWW www = new WWW(collection.gamesInCollection[j].imageUrl);
                yield return www;
                Texture2D texture = www.texture;
                collection.gamesInCollection[j].icon = Sprite.Create(texture, 
                                new Rect(0,0, texture.width, texture.height),
                                Vector2.zero);
            }
            AddCollection(collection);
        }
    }

    private void AddCollection(GameCollection collection)
    {
        grid.transform.AddChild(gameCollectionPrefab);

        var data = grid.transform.GetChild(grid.transform.childCount-1).GetComponent<CollectionController>();
        data.copy = collection;
        data.SetParams();

        myCollection.Add(data);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
        Save();
    }

    private void OnApplicationPause()
    {
        Debug.Log("OnApplicationPause");
        Save();
    }

    public void Save()
    {
        SaveSystem.SaveNames(this);
        for (int i = 0; i < myCollection.Count; i++)
            SaveSystem.SaveCollection(myCollection[i]);
    }

    public void OpenSearch()
    {
        searchPanel.SetActive(true);
    }

    public void CloseSearch()
    {
        searchPanel.SetActive(false);
    }
}
