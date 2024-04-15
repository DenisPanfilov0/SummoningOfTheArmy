using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private UnitConfig _config;

        [SerializeField] private Button _selectHero;

        [SerializeField] private Image _spriteHero;

        private Outline _outline;

        public UnitConfig Config
        {
            get => _config;
            set => _config = value;
        }

        public Button SelectHero
        {
            get => _selectHero;
            set => _selectHero = value;
        }

        private void Start()
        {
            if (Config.IsUsedDeca)
            {
                ChangeOutline(true);
            }
            else
            {
                ChangeOutline(false);
            }
        }

        public void ChangeOutline()
        {
            _outline.enabled = !_outline.enabled;
        }

        public void ChangeSpriteHero(Sprite hero)
        {
            _spriteHero.sprite = hero;
        }
        
        private void ChangeOutline(bool isUsed)
        {
            if (!_outline)
            {           
                _outline = GetComponent<Outline>();
            }

            _outline.enabled = isUsed;
        }
    }
}