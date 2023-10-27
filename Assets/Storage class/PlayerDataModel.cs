using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDataModel : IModel
{
    [JsonProperty("id")]
    public int id;
    [JsonProperty("Name")]
    public string Name;        
    [JsonProperty("Items")]
    public ItemModel[] Items;
    [JsonProperty("CurrentItem")]
    public ItemModel CurrentItem;
    [JsonProperty("Item")]
    public ITEM_TYPE Item = ITEM_TYPE.CONSUMABLE;
    public int Version { get ; set ; }
}


public enum ITEM_TYPE
{
    DEFENCE,
    ATTACK,
    CONSUMABLE
}


public interface IModel
{
    public int Version { get; set; }
}


public static class PlayerData
{

    readonly static int Version = 2;

    public static PlayerDataModel GetDefault()
    {
        return new PlayerDataModel();
    }

    public static PlayerDataModel OverrideValuesFromPreviusVersion(PlayerDataModel playerModel)
    {
        playerModel.CurrentItem = new ItemModel();
        return playerModel;
    }


    public static PlayerDataModel ValidateVersion(PlayerDataModel playerDataModel)
    {
        if(playerDataModel.Version < Version)
        {
            if(Version == 0)
            {
                var versionConverter = new ConverterFromVersion0();
                playerDataModel = versionConverter.GetPlayerModel(playerDataModel);
            }
            else if(Version == 1)
            {
                var versionConverter = new ConverterFromVersion2();
                playerDataModel = versionConverter.GetPlayerModel(playerDataModel);
            }
        }
        return playerDataModel;
    }

}


public interface VersionStrategy
{
    public PlayerDataModel GetPlayerModel(PlayerDataModel player);
}

public class ConverterFromVersion0 : VersionStrategy
{
    public PlayerDataModel GetPlayerModel(PlayerDataModel player)
    {
        player = new PlayerDataModel();
        player.Name = player.Name +"2";
        return player;
    }
}

public class ConverterFromVersion2 : VersionStrategy
{
    public PlayerDataModel GetPlayerModel(PlayerDataModel player)
    {
        player = new PlayerDataModel();
        player.Name = player.Name + "4";
        return player;
    }
}