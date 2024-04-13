using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CodeBase
{
    public class Games : MonoBehaviour
    {
        [FormerlySerializedAs("_deca")] [SerializeField] private GameDeck deck;

        [SerializeField] private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(AddHeroInDeca);
        }

        private void AddHeroInDeca()
        {
            HeroConfig heroConfig = new HeroConfig(1, damage: 10);

            foreach (var deca in deck.Deck)
            {
                if (heroConfig.Id == deca.Id)
                {
                    deck.Deck.Remove(deca);
                    return;
                }
            }
        }
    }
}