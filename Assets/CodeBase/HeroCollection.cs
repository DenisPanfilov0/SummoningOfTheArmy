using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase
{
    [CreateAssetMenu(fileName = "HeroCollection", menuName = "Configs/Hero Collection")]
    public class HeroCollection : ScriptableObject
    {
        [FormerlySerializedAs("_heroCollection")] [SerializeField] private List<UnitConfig> _collection;

        public List<UnitConfig> Collection => _collection;
        
        public void SaveData()
        {
            SaveManager.SaveData(this, name);
        }

        public void LoadData(string stringKey)
        {
            SaveManager.LoadData(this, stringKey);
        }
    }
}