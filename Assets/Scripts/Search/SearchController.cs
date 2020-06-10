using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchController : MonoBehaviour
{
    public PasteData pasteData;
    [SerializeField]private string request;
    [SerializeField] private UIInput input;
    [SerializeField] private UIInput collectionInput;
    [SerializeField] private GameObject helpContainer;
    public GamesList gamesList = new GamesList();

    private string response;
    private bool isMinData;

    public void Search()
    {
        helpContainer.SetActive(false);
        isMinData = false;
        var list = new Games();
        request = input.value;
        StartCoroutine(SearchByTitle());
    }

    public void SearchMinData()
    {
        isMinData = true;
        var list = new Games();
        request = collectionInput.value;
        StartCoroutine(SearchByTitle());
    }

    private IEnumerator SearchByTitle()
    {
        WWWForm form = new WWWForm();
        form.AddField("title", request);
        WWW www = new WWW("http://f0435451.xsph.ru/db-stopgame/", form);
        yield return www;
        if (www.error != null)
        {
            Debug.LogError("Ошибка" + www.error);
            yield break;
        }
        
        //Debug.Log("Search return is: " + www.text);
        response = www.text;

        PrintSearchResult();
    }

    private void PrintSearchResult()
    {
        var serachJsonResult = response;
        Debug.Log("Json is: " + serachJsonResult);

        if (serachJsonResult == null || serachJsonResult == "")
            Debug.Log("Игра не найдена");
        else
        {
            gamesList = JsonUtility.FromJson<GamesList>(serachJsonResult);
            Debug.Log("Игр найдено: " + gamesList.Games.Count);
            pasteData.PasteDataOnGameBoxes(isMinData);
        }
    }
}
