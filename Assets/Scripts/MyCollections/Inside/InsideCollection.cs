using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InsideCollection : MonoBehaviour
{
    [Title("Links")]
    public UIGrid grid;
    public UILabel collectionName;
    [SerializeField] private UILabel deleteButtonLabel;
    [SerializeField] private GameObject addButton;
    

    [Title("Prefabs")]
    public GameBox gameBoxPrefab;

    [Title("Data")]
    public List<GameBox> collectionObjects;


    public void AddInInsideCollection()
    {
        var index = grid.transform.childCount - 1;

        collectionObjects.Add(grid.GetChild(index).GetComponent<GameBox>());
    }
    
    public void SetDefault()
    {
        deleteButtonLabel.text = deleteText;
        isDelete = false;
        addButton.SetActive(true);
    }

    [SerializeField] private bool isDelete = false;
    private string deleteText = "Delete";
    private string cancelText = "Cancel";

    public void DeleteButton()
    {
        addButton.SetActive(isDelete);
        isDelete = !isDelete;
        deleteButtonLabel.text = isDelete == false ? deleteText : cancelText ;

        if (grid.transform.childCount > 0)
        {
            ChangeElementsColor();
        }

    }

    private void ChangeElementsColor()
    {
        foreach (var obj in collectionObjects)
        {
            obj.ChangeBackgroundColor(isDelete);
        }
    }
}
