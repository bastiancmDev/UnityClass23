using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CardSOCustom", menuName = "ScriptableObjects/NewCard", order = 1)]

public class CardSO : ScriptableObject
{
    public Texture2D Img;
    public string Name;
    public string Description;
    public int Attack;
    public int Defence;
    public int Type;
}
