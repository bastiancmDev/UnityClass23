using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemModel
{
    [JsonProperty("id")]
    public int id;
    [JsonProperty("count")]
    public int count;
}
