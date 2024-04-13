using System;
using CodeBase;
using UnityEngine;
using UnityEngine.UI;

public class DeckFiller : MonoBehaviour
{
    [SerializeField] private Image[] _deck;

    [SerializeField] private GameDeck _gameDeck;

    private void Start()
    {
        FillDeck();
        
        GetComponentInParent<InventoryFiller>().OnChangeDeck += Printer;
    }

    private void FillDeck()
    {
        foreach (var image in _deck)
        {
            image.color = Color.white;
        }
        
        for (int i = 0; i < _gameDeck.Deck.Count; i++)
        {
            _deck[i].sprite = _gameDeck.Deck[i].Image;
        }
    }

    private void Printer()
    {
        Debug.Log("ergergregregergr");
        Debug.Log("ergergregregergr");
        Debug.Log("ergergregregergr");
        Debug.Log("ergergregregergr");
    }
}
