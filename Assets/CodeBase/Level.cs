using System;
using CodeBase.Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentLevel;
        
        //TODO плохой нейминг
        [SerializeField] private LevelConfig _levelConfig;

        public void Init(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
            FillLevel();
        }

        private void FillLevel()
        {
            _currentLevel.text = _levelConfig.CurrnetLevel.ToString();
        }
    }
}
