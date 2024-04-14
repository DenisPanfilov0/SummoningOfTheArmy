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
    [SerializeField] private GameObject _upgradeInfoWindow;

    private UpgradeInfoWindowFiller _upgradeInfoWindowFiller;

    private void Start()
    {
        Init();
        _openPurchaseWindow.onClick.AddListener(OpenUpgradeInfoWindow);
        _upgradeInfoWindowFiller = _upgradeInfoWindow.GetComponent<UpgradeInfoWindowFiller>();
    }

    public void Init()
    {
        _currenUpgradeLevel = _upgradeInfo.CurrenUpgradeLevel;

        if (!CanBuyItem()) 
            SetMaxLevel();

        if (_currenUpgradeLevel > 0)
        {
            foreach (var upgrade in _nexUpgrade)
                if (upgrade != null) 
                    upgrade.SetActive(true);
        }
        else
        {
            foreach (var upgrade in _nexUpgrade)
                if (upgrade != null) 
                    upgrade.SetActive(false);
        }
    }

    private void SetMaxLevel()
    {
        /*_currentLevel.text = "Max";
        _currentLevel.color = Color.white;*/
        Destroy(_maxLevelIndicator);
    }

    private void OpenUpgradeInfoWindow()
    {
        _upgradeInfoWindow.SetActive(true);
        _upgradeInfoWindowFiller.Init(_upgradeInfo);
        _upgradeInfoWindowFiller.SetButtonClickHandler(_upgradeInfo, this);
    }

    private bool CanBuyItem()
    {
        return _upgradeInfo.CurrenUpgradeLevel != _upgradeInfo.MaxUpgradeLevel;
    }
}
