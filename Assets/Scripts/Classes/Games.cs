using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class Games
{
    [Title("Game Data")]
    public string title;
    public string genre1;
    public string genre2;
    public string platform;
    public string gameDate;
    public float tag;

    [Title("Game Links")]
    public string imageUrl;
    public string gameUrl;

    [Title("Not in db")]
    public Sprite icon;
}
