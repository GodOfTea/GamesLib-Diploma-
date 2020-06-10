using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

public class CollectionController : MonoBehaviour
{
    [Title("Links")]
    [SerializeField] private PanelController panelController;
    public InsideCollection insideCollection;

    [Title("UILabels")]
    public UILabel collectionName;
    public UILabel gamesCount;

    [Title("UI2DSprite")]
    [SerializeField] private List<UI2DSprite> gameIcons;

    [Title("GameCollectionCopy")]
    public GameCollection copy;

    private CollectionController collection;


    private void Start()
    {
        panelController = GameObject.FindGameObjectWithTag("Core").GetComponent<PanelController>();
        insideCollection = GameObject.FindGameObjectWithTag("Collection").GetComponent<InsideCollection>();
    }

    public void Open()
    {
        //collection = MyCollectionsPanelController.OpenedCollection;
        MyCollectionsPanelController.OpenedCollection = gameObject.GetComponent<CollectionController>();

        insideCollection.collectionName.text = copy.collectionName;
        insideCollection.SetDefault();
        insideCollection.grid.transform.DestroyChildren();
        insideCollection.collectionObjects.RemoveRange(0, insideCollection.collectionObjects.Count);
        SpawnGames();

        insideCollection.grid.Reposition();

        panelController.OpenCollectionPanel();
    }

    public void SetParams()
    {
        collectionName.text = copy.collectionName;
        gamesCount.text = "Игры: " + copy.gamesCount;

        //gameIcons[0].sprite2D = copy.gameIcons[0];
        //gameIcons[1].sprite2D = copy.gameIcons[1];
        //gameIcons[2].sprite2D = copy.gameIcons[2];
    }

    private void SpawnGames()
    {
        var length = copy.gamesInCollection.Count;

        if (length != 0)
        {
            for (int i = 0; i < length; i++)
            {
                insideCollection.grid.gameObject.AddChild(PasteGameInObj(i));
                insideCollection.AddInInsideCollection();
            }
        }
    }

    private GameObject PasteGameInObj(int i)
    {
        var obj = insideCollection.gameBoxPrefab;

        obj.game = copy.gamesInCollection[i];
        obj.title.text = obj.game.title;
        obj.icon.sprite2D = obj.game.icon;
        obj.isCollectionSearch = false;

        return obj.gameObject;
    }

    public void AddGame()
    {
        var index = copy.gamesInCollection.Count-1;

        insideCollection.grid.gameObject.AddChild(PasteGameInObj(index));
        insideCollection.AddInInsideCollection();

        copy.gamesCount += 1;
    }


    /*gamesInCollection - открывать по нажатию*/
}
