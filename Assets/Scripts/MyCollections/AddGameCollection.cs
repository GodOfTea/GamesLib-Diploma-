using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameCollection : MonoBehaviour
{
    [SerializeField] private MyCollectionsPanelController myCollectionsPanelController;
    [SerializeField] private UIGrid collectionsGrid;
    [SerializeField] private GameObject collectionNamePanel;
    [SerializeField] private GameObject gameCollectionPrefab;
    [SerializeField] private UIInput nameInput;
    [SerializeField] private Sprite emptyIcon;

    [SerializeField] private GameCollection newCollection;

    public void AddNewGameCollection()
    {
        newCollection = new GameCollection();
        newCollection.gamesInCollection = new List<Games>();
        collectionNamePanel.SetActive(true);
    }

    public void SetCollectionName()
    {
        newCollection.collectionName = nameInput.value;
        StartCoroutine(SpawnCollection());
    }

    private IEnumerator SpawnCollection()
    {
        newCollection.gamesCount = 0;

        List<Sprite> icons = new List<Sprite>();
        for (int i = 0; i < 3; i++)
        {
            icons.Add(emptyIcon);
        }
        newCollection.gameIcons = icons;

        collectionsGrid.transform.AddChild(gameCollectionPrefab);
        yield return new WaitForSeconds(0.1f);
        collectionsGrid.Reposition();

        var index = collectionsGrid.transform.childCount - 1;
        var data = collectionsGrid.transform.GetChild(index).GetComponent<CollectionController>();

        data.copy = newCollection;
        data.SetParams();
        myCollectionsPanelController.myCollection.Add(data);

        collectionNamePanel.SetActive(false);
    }
}
