using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{


    public List<CardSO> Decks;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var card in Decks)
        {
            Debug.Log(card.Description);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var card in Decks)
        {
            card.Description = "El peor";
        }
    }
}
