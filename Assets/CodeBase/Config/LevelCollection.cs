using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Config
{
    [CreateAssetMenu(fileName = "LevelCollection", menuName = "Configs/Level Collection")]
    public class LevelCollection : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levelConfigs;
        
        public List<LevelConfig> LevelConfigs
        {
            get => _levelConfigs;
            set => _levelConfigs = value;
        }
    }
}