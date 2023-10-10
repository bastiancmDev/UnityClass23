using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanelMenuInterface
{
    public PANEL_TYPE Id { get; set; }
    public void AppearPanel();
    public void HiddenPanel();
    public void OnPanelIsActive();

}


public enum PANEL_TYPE{
    MAIN_MENU,
    FINAL_PANEL,
}
