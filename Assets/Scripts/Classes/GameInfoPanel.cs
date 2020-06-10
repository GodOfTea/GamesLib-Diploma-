using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameInfoPanel : MonoBehaviour
{
    [Title("Data")]
    [SerializeField] private Games game;

    [SerializeField] private string dateText = "Дата выхода: ";
    [SerializeField] private string platformText = "Платформа: ";
    [SerializeField] private string generText = "Жанр: ";

    [Title("Attributes", "UI2DSprite")]
    [SerializeField] private UI2DSprite uiSprite;

    [Title("Attributes", "UILabel")]
    [SerializeField] private UILabel uiGameName;
    [SerializeField] private UILabel uiRate;
    [SerializeField] private UILabel uiReleaseDate;
    [SerializeField] private UILabel uiPlatform;
    [SerializeField] private UILabel uiGener;


    public void SetData(Games openedGame)
    {
        game = openedGame;
        StartCoroutine(SetPatams());
    }

    private IEnumerator SetPatams()
    {
        uiGameName.text    = game.title;
        uiRate.text        = game.tag.ToString();
        uiReleaseDate.text = dateText + game.gameDate;
        uiPlatform.text    = platformText + game.platform;
        uiGener.text       = generText + (game.genre2 == "" ? game.genre1 : game.genre1 + "," + game.genre2);

        WWW www = new WWW(game.imageUrl);
        yield return www;
        Texture2D texture = www.texture;
        uiSprite.sprite2D = Sprite.Create(texture, 
                                    new Rect(0,0, texture.width, texture.height),
                                    Vector2.zero);
    }
}
