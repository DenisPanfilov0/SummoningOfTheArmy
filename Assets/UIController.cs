using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _createMageButton;
    [SerializeField] private Button _createKnightButton;
    [SerializeField] private Button _createDemonButton;
    [SerializeField] private Transform _allyPrefabSpawnPosition;
    [SerializeField] private Transform _enemyPrefabSpawnPosition;
    [SerializeField] private List<UnitConfig> _configs;

    private void Awake()
    {
        _createMageButton.onClick.AddListener(CreateMage);
        _createKnightButton.onClick.AddListener(CreateKnight);
        _createDemonButton.onClick.AddListener(CreateDemon);
    }
    
    private void CreateMage()
    {
        var mageConfig = Resources.Load<UnitConfig>("Configs/Units/MageConfig");
        AllyCreator creator = new MageCreator(mageConfig);
        MageUnit mageUnit = (MageUnit)creator.FactoryMethod(_allyPrefabSpawnPosition);
    }

    private void CreateKnight()
    {
        var knightConfig = Resources.Load<UnitConfig>("Configs/Units/KnightConfig");
        AllyCreator creator = new KnightCreator(knightConfig);
        KnightUnit knightUnit = (KnightUnit)creator.FactoryMethod(_allyPrefabSpawnPosition);
    }

    private void CreateDemon()
    {
        var demonConfig = Resources.Load<UnitConfig>("Configs/Units/DemonConfig");
        EnemyCreator creator = new DemonCreator(demonConfig);
        DemonUnit demonUnit = (DemonUnit)creator.FactoryMethod(_enemyPrefabSpawnPosition);
    }
}
