using System;
using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class ManaBasedHeroSpawner : MonoBehaviour
    {
        [SerializeField] private Button _heroSpawn;

        [SerializeField] private ManaPoolScript _manaPool;

        [SerializeField] private UnitConfig _unitConfig;

        public void Init(UnitConfig config, ManaPoolScript manaPool)
        {
            _unitConfig = config;
            _manaPool = manaPool;
        }

        private void Update()
        {
            if (_manaPool.CurrentMana >= _unitConfig.CostSummoner)
            {
                _heroSpawn.interactable = true;
            }
            else
            {
                _heroSpawn.interactable = false;
            }
        }
    }
}