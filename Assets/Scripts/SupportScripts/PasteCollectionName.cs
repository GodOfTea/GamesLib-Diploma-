using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasteCollectionName : MonoBehaviour
{
    [SerializeField] private UILabel collectionName;

    private CollectionController collection;

    private void Start()
    {
        collection = MyCollectionsPanelController.OpenedCollection;

        collectionName.text = collection.collectionName.text;
    }
}
