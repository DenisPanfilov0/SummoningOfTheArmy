using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase
{
    [CreateAssetMenu(fileName = "NewGameDeca", menuName = "Configs/Game Deca")]
    public class GameDeck : ScriptableObject
    {
        [FormerlySerializedAs("_deca")] [SerializeField] private List<UnitConfig> _deck;

        public List<UnitConfig> Deck => _deck;
    }
}