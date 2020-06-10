using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.ComponentModel;

public class PanelController : MonoBehaviour
{
    [Title("Current Panel")]
    public UIPanel currentPanel;

    [Title("Panels")]
    public UIPanel homePanel;
    public UIPanel myCollectionsPanel;
    public UIPanel settingsPanel;
    public UIPanel collectionPanel;
    public UIPanel gameInfoPanel;


    private void Start()
    {
        SwitchPanel(homePanel);
    }

    public void OpenHomePanel()
    {
        Debug.Log("Открыта: " + homePanel.ToString());
        SwitchPanel(homePanel);
    }

    public void OpenMyCollectionsPanel()
    {
        Debug.Log("Открыта: " + myCollectionsPanel.ToString());
        SwitchPanel(myCollectionsPanel);
    }

    public void OpenSettingsPanel()
    {
        Debug.Log("Открыта: " + settingsPanel.ToString());
        SwitchPanel(settingsPanel);
    }

    public void OpenCollectionPanel()
    {
        Debug.Log("Открыта: " + collectionPanel.ToString());
        SwitchPanel(collectionPanel);
    }

    public void OpenGameInfoPanel(Games game)
    {
        Debug.Log("Открыта: " + gameInfoPanel.ToString());
        
        SwitchPanel(gameInfoPanel);
        gameInfoPanel.GetComponent<GameInfoPanel>().SetData(game);
    }

    private void SwitchPanel(UIPanel panel)
    {
        if (currentPanel != null)
            currentPanel.gameObject.SetActive(false);
        currentPanel = panel;
        currentPanel.gameObject.SetActive(true);
    }
}
