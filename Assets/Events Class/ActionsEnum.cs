

using System;

public enum ACTIONSYSTEM
{
    TESTSAVEDATA,
    CREATEPLAYER,
    GETPLAYER
}

public interface EventParameter
{
    ACTIONSYSTEM KeyAction{ get; set; }

    Delegate ActionDelegate { get; set; }

}


public class GetPlayerParameter : EventParameter
{
    public ACTIONSYSTEM KeyAction { get ; set ; }
    public Delegate ActionDelegate { get ; set ; }
}