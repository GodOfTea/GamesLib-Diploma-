using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameBox : MonoBehaviour
{
    [Title("Data")]
    public Games game;
    public bool isCollectionSearch;
    [SerializeField, ColorUsage(true)]
    private Color deleteColor;
    [SerializeField, ColorUsage(true)]
    private Color defaultColor;

    [Title("Links")]
    public UILabel title;
    public UI2DSprite icon;
    public UISprite background;


    private int collectionWidth = 800;
    private int homeSearchWidth = 980;

    private void Start()
    {
        gameObject.GetComponent<UIWidget>().width = isCollectionSearch == true ?
                                                collectionWidth : homeSearchWidth;
    }

    public void Click()
    {
        if (background.color == deleteColor)
            Delete();
        else if (!isCollectionSearch)
            Open();
        else
            Add();
    }

    private void Add()
    {
        var collection = MyCollectionsPanelController.OpenedCollection;
        //isCollectionSearch = false;

        collection.copy.gamesInCollection.Add(game);
        collection.AddGame();
        collection.insideCollection.grid.Reposition();
    }

    private void Delete()
    {
        var collection = MyCollectionsPanelController.OpenedCollection;

        /* Костыль */
        foreach (var gameInfo in collection.copy.gamesInCollection)
        {
            if (gameInfo.title == game.title)
            {
                collection.copy.gamesInCollection.Remove(gameInfo);
                break;
            }
        }
        //collection.copy.gamesInCollection.Remove(game);
        collection.insideCollection.collectionObjects.Remove(gameObject.GetComponent<GameBox>());
        Destroy(gameObject);

        collection.copy.gamesCount -= 1;

        collection.insideCollection.grid.Reposition();
    }

    private void Open()
    {
        var panel = GameObject.FindGameObjectWithTag("Core").GetComponent<PanelController>();
        panel.OpenGameInfoPanel(game);
    }

    public void ChangeBackgroundColor(bool isDelete)
    {
        if (isDelete == true)
            background.color = deleteColor;
        else
            background.color = defaultColor;
    }
}
