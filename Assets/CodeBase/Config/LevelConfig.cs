using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Config
{
    [CreateAssetMenu(fileName = "NewLevel", menuName = "Configs/New Level")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<EnemySpawnConfig> _spawnConfig;

        [SerializeField] private int _currnetLevel;
        
        public List<EnemySpawnConfig> SpawnConfig
        {
            get => _spawnConfig;
            set => _spawnConfig = value;
        }
        
        public int CurrnetLevel
        {
            get => _currnetLevel;
            set => _currnetLevel = value;
        }
    }
    
    
    [System.Serializable]
    public class EnemySpawnConfig
    {
        [Header("Здесь ссылка на конкретный SO врага")] 
        [SerializeField] private string _enemy;

        [Header("Количество этих врагов")]
        [SerializeField] private int _enemyAmount;
        
        public string Enemy
        {
            get => _enemy;
            set => _enemy = value;
        }
        
        public int EnemyAmount
        {
            get => _enemyAmount;
            set => _enemyAmount = value;
        }
    }
}