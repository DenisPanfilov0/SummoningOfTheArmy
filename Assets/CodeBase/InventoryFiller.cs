using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CodeBase
{
    public class InventoryFiller : MonoBehaviour
    {
        [SerializeField] private HeroCollection _heroCollection;

        [SerializeField] private GameDeck _gameDeck;

        [SerializeField] private Transform _contentParent;

        [SerializeField] private GameObject _heroPrefab;

        [SerializeField] private UnitConfig _currentHeroConfig;

        [SerializeField] private Button _equipAHero;

        [SerializeField] private Button _unEquipAHero;

        [SerializeField] private Hero _currentHero;

        public event Action OnChangeDeck;

        private void Start()
        {
            FillInventory();
            
            _equipAHero.onClick.AddListener(AddHeroToDeck);
            _unEquipAHero.onClick.AddListener(RemoveHeroToDeck);
        }

        private void FillInventory()
        {
            foreach (var heroConfig in _heroCollection.Collection)
            {
                GameObject obj = Instantiate(_heroPrefab, _contentParent);
                Hero hero = obj.GetComponent<Hero>();
                hero.Config = heroConfig;
                hero.SelectHero.onClick.AddListener(() => SelectHero(heroConfig, hero));
                hero.ChangeSpriteHero(heroConfig.Image);
            }
        }

        private void SelectHero(UnitConfig heroConfig, Hero hero)
        {
            if (_currentHero != null)
            {
                _currentHero.GetComponent<Image>().color = Color.white;
            }
            
            _currentHero = hero;
            _currentHeroConfig = heroConfig;
            
            _currentHero.GetComponent<Image>().color = Color.grey;

            if (heroConfig.IsUsedDeca)
                SetInteractableButtons(false, true);
            else
                SetInteractableButtons(true, false);
        }

        private void AddHeroToDeck()
        {
            _currentHero.ChangeOutline();
            _currentHeroConfig.IsUsedDeca = !_currentHeroConfig.IsUsedDeca;
            SetInteractableButtons(false, true);
            _gameDeck.Deck.Add(_currentHeroConfig);
            OnChangeDeck?.Invoke();
        }
        
        private void RemoveHeroToDeck()
        {
            _currentHero.ChangeOutline();
            _currentHeroConfig.IsUsedDeca = !_currentHeroConfig.IsUsedDeca;
            SetInteractableButtons(true, false);
            _gameDeck.Deck.Remove(_currentHeroConfig);
            OnChangeDeck?.Invoke();
        }
        
        private void SetInteractableButtons(bool equipInteractable, bool unEquipInteractable)
        {
            _equipAHero.interactable = equipInteractable;
            _unEquipAHero.interactable = unEquipInteractable;
        }
    }
}