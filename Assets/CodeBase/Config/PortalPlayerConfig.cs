using UnityEngine;

namespace CodeBase.Config
{
    [CreateAssetMenu(fileName = "PlayerPortal", menuName = "Configs/Player Portal Config")]
    public class PortalPlayerConfig : ScriptableObject
    {
        [SerializeField] private float _portalHealth;
        
        public float PortalHealth
        {
            get => _portalHealth;
            set => _portalHealth = value;
        }
    }
}