using System;
using CodeBase.Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class ShopItemHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentLevel;
    [SerializeField] private Button _openPurchaseWindow;
    [SerializeField] private UnitUpgrade _upgradeInfo;
    [SerializeField] private GameObject _maxLevelIndicator;
    [SerializeField] private GameObject[] _nexUpgrade;
    
    [SerializeField] private int _currenUpgradeLevel;
    [SerializeField] private int _maxUpgradeLevel;
    [SerializeField] private float _priceItem;
    [SerializeField] private float _priceModifier;

    private void Start()
    {
        Init();
        _openPurchaseWindow.onClick.AddListener(BuyItem);
    }

    private void Init()
    {
        _currenUpgradeLevel = _upgradeInfo.CurrenUpgradeLevel;
        _maxUpgradeLevel = _upgradeInfo.MaxUpgradeLevel;
        _priceItem = _upgradeInfo.PriceItem;
        _priceModifier = _upgradeInfo.PriceModifier;

        if (!CanBuyItem()) 
            SetMaxLevel();

        if (_currenUpgradeLevel > 0)
        {
            foreach (var upgrade in _nexUpgrade)
            {
                upgrade.SetActive(true);
            }
        }
    }

    private void BuyItem()
    {
        if (CanBuyItem())
        {
            Debug.Log("Списали души за покупку");
            _upgradeInfo.CurrenUpgradeLevel++;
            _upgradeInfo.PriceItem *= _upgradeInfo.PriceModifier;
            Init();
        }
    }

    private void SetMaxLevel()
    {
        /*_currentLevel.text = "Max";
        _currentLevel.color = Color.white;*/
        Destroy(_maxLevelIndicator);
    }

    private bool CanBuyItem() => 
        _upgradeInfo.CurrenUpgradeLevel != _upgradeInfo.MaxUpgradeLevel;
}
