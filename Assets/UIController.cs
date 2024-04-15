using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _createMageButton;
    [SerializeField] private Transform _magePrefabSpawnPosition;
    [SerializeField] private List<UnitConfig> _configs;

    private void Awake()
    {
        _createMageButton.onClick.AddListener(CreateMage);
    }
    
    private void CreateMage()
    {
        var mageConfig = Resources.Load<MageConfig>("Configs/Units/MageConfig");
        AllyCreator creator = new MageCreator(mageConfig);
        MageUnit mageUnitUnit = (MageUnit)creator.FactoryMethod(_magePrefabSpawnPosition);
    }
}
