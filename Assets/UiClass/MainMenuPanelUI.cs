using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanelUI : MonoBehaviour , IPanelMenuInterface
{
    public Button StartBtn;

    public PANEL_TYPE Id { get; set; }

    void Start()
    {
        Id = PANEL_TYPE.MAIN_MENU;
        StartBtn.onClick.AddListener(CallLaunchCinmatic);
        UIGameController uiController = FindObjectOfType<UIGameController>();
        //uiController.OnCinematicStart += OnCinematicStart;
        //uiController.OnCinematicEnd += OnCinematicEnd;
        uiController.panels.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CallLaunchCinmatic()
    {
        UIGameController uiController = FindObjectOfType<UIGameController>();
        uiController.CinematicStart();
    }


    public void OnCinematicStart()
    {
        gameObject.SetActive(false);
    }

    public void OnCinematicEnd()
    {
        gameObject.SetActive(true);
    }

    public void AppearPanel()
    {
        gameObject.SetActive(true);
    }

    public void HiddenPanel()
    {
        gameObject.SetActive(false);
    }

    public void OnPanelIsActive()
    {
        
    }
}
