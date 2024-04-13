using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CodeBase
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewHeroConfig", menuName = "Configs/Hero")]
    public class HeroConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private bool _isUsedDeca;
        [SerializeField] private Sprite _image;

        public int Id => _id;
        public int Health => _health;
        public int Damage => _damage;
        
        public bool IsUsedDeca
        {
            get => _isUsedDeca;
            set => _isUsedDeca = value;
        }

        public Sprite Image => _image;

        public HeroConfig(int id = 0, int health = 0, int damage = 0)
        {
            _id = id;
            _health = health; 
            _damage = damage;
        }
    }
}