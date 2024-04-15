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
        _createMageButton.onClick.AddListener(CreateKnight);
    }
    
    private void CreateMage()
    {
        var mageConfig = Resources.Load<UnitConfig>("Configs/Units/MageConfig");
        AllyCreator creator = new MageCreator(mageConfig);
        MageUnit mageUnit = (MageUnit)creator.FactoryMethod(_magePrefabSpawnPosition);
    }

    private void CreateKnight()
    {
        var knightConfig = Resources.Load<UnitConfig>("Configs/Units/KnightConfig");
        AllyCreator creator = new KnightCreator(knightConfig);
        KnightUnit knightUnit = (KnightUnit)creator.FactoryMethod(_magePrefabSpawnPosition);
    }
}
