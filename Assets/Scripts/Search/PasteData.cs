using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PasteData : MonoBehaviour
{
    [Title("Links")]
    public SearchController searchController;
    
    [Title("Data")]
    [SerializeField] private UIGrid mainSearchgrid;
    [SerializeField] private UIGrid collectionSearchGrid;

    [Title("Prefabs")]
    [SerializeField] private GameObject gameBoxPrefab; 

    [Title("Data", "GameList")]
    [SerializeField] private GamesList gamesList;

    private UIGrid grid;
    private GameObject child;
    private bool isCollectionSearch;
     public void PasteDataOnGameBoxes(bool isCollection)
     {
         /* Переменные */
         gamesList  = searchController.gamesList;
         int length = gamesList.Games.Count;
         isCollectionSearch = isCollection;
         child = gameBoxPrefab;
         grid = isCollection == true ? collectionSearchGrid : mainSearchgrid;

         if (grid.transform.childCount > 0)
           grid.transform.DestroyChildren();

         for (int i = 0; i < length; i++)
         {
            grid.transform.AddChild(child);
            StartCoroutine(PasteInGameBox(i));
         }
         
     }

     private IEnumerator PasteInGameBox(int i)
     {
        var data = grid.transform.GetChild(i).GetComponent<GameBox>();

        data.game = gamesList.Games[i];
        data.isCollectionSearch = isCollectionSearch;

        data.title.text   = data.game.title;

        WWW www = new WWW(data.game.imageUrl);
        yield return www;
        Texture2D texture = www.texture;
        data.icon.sprite2D = Sprite.Create(texture, 
                                    new Rect(0,0, texture.width, texture.height),
                                    Vector2.zero);

         data.game.icon = data.icon.sprite2D;

        grid.Reposition();
     }
}
