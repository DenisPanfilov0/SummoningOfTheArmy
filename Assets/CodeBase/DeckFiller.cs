using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class DeckFiller : MonoBehaviour
    {
        [SerializeField] private Image[] _deck;

        [SerializeField] private GameDeck _gameDeck;

        [SerializeField] private Sprite _border;

        private void Start()
        {
            FillDeck();
        
            GetComponentInParent<InventoryFiller>().OnChangeDeck += FillDeck;
        }

        private void FillDeck()
        {
            foreach (var image in _deck)
            {
                image.sprite = _border;
            }
        
            for (int i = 0; i < _gameDeck.Deck.Count; i++)
            {
                _deck[i].sprite = _gameDeck.Deck[i].Image;
            }
        }
    }
}