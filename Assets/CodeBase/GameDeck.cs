using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase
{
    [CreateAssetMenu(fileName = "NewGameDeca", menuName = "Configs/Game Deca")]
    public class GameDeck : ScriptableObject
    {
        [FormerlySerializedAs("_deca")] [SerializeField] private List<HeroConfig> _deck;

        public List<HeroConfig> Deck => _deck;
    }
}