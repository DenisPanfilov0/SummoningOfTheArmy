using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase
{
    [CreateAssetMenu(fileName = "HeroCollection", menuName = "Configs/Hero Collection")]
    public class HeroCollection : ScriptableObject
    {
        [FormerlySerializedAs("_heroCollection")] [SerializeField] private List<HeroConfig> _collection;

        public List<HeroConfig> Collection => _collection;
    }
}