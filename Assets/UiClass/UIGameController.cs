using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameController : MonoBehaviour
{
    public Action OnCinematicStart;
    public Action OnCinematicEnd;


    public List<IPanelMenuInterface> panels;

    public void Awake()
    {
        panels = new List<IPanelMenuInterface>();
    }

    public void CinematicStart()
    {
        //OnCinematicStart?.Invoke();
        HiddePanel(PANEL_TYPE.MAIN_MENU);
    }

    public void CinematicEnd()
    {
        //OnCinematicEnd?.Invoke();
        AppearPanel(PANEL_TYPE.MAIN_MENU);
    }

    public void AppearPanel(PANEL_TYPE id)
    {
        foreach (var panel in panels)
        {
            if(panel.Id == id)
            {
                panel.AppearPanel();
            }
        }
    }

    public void HiddePanel(PANEL_TYPE id)
    {
        foreach (var panel in panels)
        {
            if (panel.Id == id)
            {
                panel.HiddenPanel();
            }
        }
    }

}
