using System;
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

    private void Start()
    {
        _closewindow.onClick.AddListener(CloseWindow);
        _closewindow.onClick.AddListener(CloseWindow);
    }

    public void Init(UnitUpgrade config, ShopItemHandler item = null)
    {
        _name.text = config.name;
        _cost.text = $"COST : {config.PriceItem}";
        _level.text = $"Lv. {config.CurrenUpgradeLevel}/{config.MaxUpgradeLevel}";
        _description.text = config.Description;
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
        config.CurrenUpgradeLevel++;
        config.PriceItem += config.PriceModifier;
        // config.PriceItem *= Mathf.Log(config.CurrenUpgradeLevel + 1) * config.PriceModifier;
        //config.PriceModifier *= config.PriceModifierDecrement;
        Init(config);
        item.Init();
    }
}
