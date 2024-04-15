using System;
using CodeBase;
using CodeBase.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfoWindowFiller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _closewindow;
    [SerializeField] private MainPlayerConfig _mainPlayerConfig;
    [SerializeField] private HeroCollection _heroCollection;

    private void Start()
    {
        _closewindow.onClick.AddListener(CloseWindow);
        _closewindow.onClick.AddListener(CloseWindow);
    }

    public void Init(UnitUpgrade config, ShopItemHandler item = null)
    {
        if (config.CurrenUpgradeLevel >= config.MaxUpgradeLevel)
        {
            _upgradeButton.interactable = false;
            _level.text = "Max";
            _name.text = config.Name;
            _cost.text = $"COST : \u221E";
            _description.text = config.Description;

        }
        else
        {
            _upgradeButton.interactable = true;
            _name.text = config.Name;
            _cost.text = $"COST : {config.PriceItem}";
            _level.text = $"Lv. {config.CurrenUpgradeLevel}/{config.MaxUpgradeLevel}";
            _description.text = config.Description;
        }
    }

    public void SetButtonClickHandler(UnitUpgrade config, ShopItemHandler item)
    {
        _upgradeButton.onClick.AddListener(() => BuyUpgrade(config, item));
    }

    private void CloseWindow()
    {
        gameObject.SetActive(false);
        _upgradeButton.onClick.RemoveAllListeners();

    }

    private void BuyUpgrade(UnitUpgrade config, ShopItemHandler item)
    {
        if (config.IsUnitUpgrade)
        {
            UnitUpgrade(config);
        }
        else if (config.IsAccountUpgrade)
        {
            AccountUpgrade(config);
        }
        else if (config.IsUnlockUnit)
        {
            UnitUnlock(config);
        }
        
        config.CurrenUpgradeLevel++;
        _mainPlayerConfig.DecreaseBalance(config.PriceItem);
        config.PriceItem += config.PriceModifier;
        Init(config);
        item.Init();
    }

    private void UnitUpgrade(UnitUpgrade config)
    {
        float damage = config.UnitUpgradeCharacteristic.DamageIncrease;
        float health = config.UnitUpgradeCharacteristic.HealthIncrease;
        config.UnitUpgradeCharacteristic.Unit.ConstantStatIncrease(damage, health);
        config.UnitUpgradeCharacteristic.Unit.StatsCalculate();
    }

    private void AccountUpgrade(UnitUpgrade config)
    {
        _mainPlayerConfig.PortalHealth += config.AccountUpgradeStat.HealthIncrease;
    }

    private void UnitUnlock(UnitUpgrade config)
    {
        _heroCollection.Collection.Add(config.Unit.Config);
    }
}
