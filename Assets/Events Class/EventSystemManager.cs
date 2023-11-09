using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemManager : MonoBehaviour
{
    public static EventSystemManager Instance;


    public Dictionary<ACTIONSYSTEM, Delegate> Actions;

    public void Awake()
    {
        Init();
        EventSystemManager.Instance.TriggerAction(ACTIONSYSTEM.TESTSAVEDATA);
    }

    public void Init()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Actions = new Dictionary<ACTIONSYSTEM, Delegate>();


        Action<string, int, float> CreatePlayerDelegate = CreatePlayer;
        EventSystemManager.Instance.AddAction(ACTIONSYSTEM.CREATEPLAYER, CreatePlayerDelegate);
        EventSystemManager.Instance.TriggerAction(ACTIONSYSTEM.CREATEPLAYER, "Claudio", 25, 1.90f);

        Func<string, int, float, string> GetPlayerDelegete = GetPlayer;
        EventSystemManager.Instance.AddAction(ACTIONSYSTEM.GETPLAYER, GetPlayerDelegete);
        string NameOfPlayer = (string) EventSystemManager.Instance.TriggerAction(ACTIONSYSTEM.CREATEPLAYER, "Claudio", 25, 1.90f);
        Debug.Log("Name of player is " + NameOfPlayer);



    }

    public void AddAction(ACTIONSYSTEM actionKey,Delegate action) 
    {
        


        if (!Actions.TryAdd(actionKey, action))
        {
            Actions[actionKey] = action;
        }
    }

    public object TriggerAction(ACTIONSYSTEM actionKey, params object[] args)
    {        

        if(Actions.TryGetValue(actionKey, out var value))
        {
             return value?.DynamicInvoke(args);
        }
        return null;
    }




    public void CreatePlayer(string name, int age, float scala)
    {
        
    }

    public string GetPlayer(string name, int age, float scala)
    {        
        return name;
    }


    



}
