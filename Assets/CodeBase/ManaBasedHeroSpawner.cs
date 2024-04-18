using System;
using CodeBase.Infrastructure.State;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class ManaBasedHeroSpawner : MonoBehaviour
    {
        [SerializeField] private Button _heroSpawn;

        [SerializeField] private ManaPoolScript _manaPool;

        [SerializeField] private UnitConfig _unitConfig;

        [SerializeField] private TextMeshProUGUI _halth;

        public void Init(UnitConfig config, ManaPoolScript manaPool)
        {
            _unitConfig = config;
            _manaPool = manaPool;
            _heroSpawn.onClick.AddListener(SpawnUnit);

            _halth.text = _unitConfig.Health.ToString();
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

        private void SpawnUnit()
        {
            _manaPool.DecreaseMana(_unitConfig.CostSummoner);
        }

        private void OnDestroy()
        {
            _heroSpawn.onClick.RemoveAllListeners();
        }
    }
}