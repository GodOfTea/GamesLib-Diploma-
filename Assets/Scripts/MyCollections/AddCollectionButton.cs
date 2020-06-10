using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollectionButton : MonoBehaviour
{
    [SerializeField] private AddGameCollection addGameCollection;


    private void Start()
    {
        addGameCollection = GameObject.FindGameObjectWithTag("Collection Panel").GetComponent<AddGameCollection>();
    }
    public void OnClick()
    {
        addGameCollection.AddNewGameCollection();
    }
}
