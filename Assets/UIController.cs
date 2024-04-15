using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Config;
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
    
    private LevelConfig _levelConfig;

    /*private void Awake()
    {
        _createMageButton.onClick.AddListener(CreateMage);
        _createKnightButton.onClick.AddListener(CreateKnight);
        _createDemonButton.onClick.AddListener(CreateDemon);
    }*/

    public void InitSpawnPoint(Transform heroSpawn, Transform enemySpawn, LevelConfig levelConfig)
    {
        _allyPrefabSpawnPosition = heroSpawn;
        _enemyPrefabSpawnPosition = enemySpawn;
        _levelConfig = levelConfig;
        CreateSpawnPoint();
    }


    public void AddListenerButton(Button _button, UnitConfig config)
    {
        switch (config.name)
        {
            case "MageConfig": _button.onClick.AddListener(CreateMage);
                break;
            
            case "KnightConfig": _button.onClick.AddListener(CreateKnight);
                break;
            
            case "DemonConfig": _button.onClick.AddListener(CreateDemon);
                break;
        }
    }

    private void CreateMage()
    {
        var mageConfig = Resources.Load<UnitConfig>("Configs/Units/MageConfig");
        string path = "Prefabs/AllyUnits/MagePrefab";
        UnitCreator creator = new MageCreator(mageConfig);
        AllyUnit mageUnit = (AllyUnit)creator.FactoryMethodAlly(path, _allyPrefabSpawnPosition);
    }

    private void CreateKnight()
    {
        var knightConfig = Resources.Load<UnitConfig>("Configs/Units/KnightConfig");
        string path = "Prefabs/AllyUnits/KnightPrefab";
        UnitCreator creator = new KnightCreator(knightConfig);
        AllyUnit knightUnit = (AllyUnit)creator.FactoryMethodAlly(path ,_allyPrefabSpawnPosition);
    }

    private void CreateDemon()
    {
        var demonConfig = Resources.Load<UnitConfig>("Configs/Units/DemonConfig");
        string path = "Prefabs/AllyUnits/DemonPrefab";
        UnitCreator creator = new DemonCreator(demonConfig);
        AllyUnit demonUnit = (AllyUnit)creator.FactoryMethodAlly(path, _allyPrefabSpawnPosition);
    }


    private void CreateEnemyMage()
    {
        var mageConfig = Resources.Load<UnitConfig>("Configs/Units/MageConfig");
        string path = "Prefabs/Enemy/EnemyMagePrefab";
        UnitCreator creator = new MageCreator(mageConfig);
        EnemyUnit mageUnit = (EnemyUnit)creator.FactoryMethodEnemy(path, _enemyPrefabSpawnPosition);
    }

    private void CreateEnemyKnight()
    {
        var knightConfig = Resources.Load<UnitConfig>("Configs/Units/KnightConfig");
        string path = "Prefabs/Enemy/EnemyKnightPrefab";
        UnitCreator creator = new KnightCreator(knightConfig);
        EnemyUnit knightUnit = (EnemyUnit)creator.FactoryMethodEnemy(path, _enemyPrefabSpawnPosition);
    }
    
    private void CreateEnemyDemon()
    {
        var demonConfig = Resources.Load<UnitConfig>("Configs/Units/DemonConfig");
        string path = "Prefabs/Enemy/EnemyDemonPrefab";
        UnitCreator creator = new DemonCreator(demonConfig);
        EnemyUnit demonUnit = (EnemyUnit)creator.FactoryMethodEnemy(path, _enemyPrefabSpawnPosition);
    }
    
    
    private void CreateSpawnPoint()
    {
        foreach (var enemy in _levelConfig.SpawnConfig)
        {
            StartCoroutine(SpawnEnemy(enemy));
        }
    }

    private IEnumerator SpawnEnemy(EnemySpawnConfig enemy)
    {
        for (int i = 0; i < enemy.EnemyAmount; i++)
        {
            switch (enemy.Enemy.name)
            {
                case "EnemyMageConfig":
                    CreateEnemyMage();
                    break;
                case "EnemyKnightConfig":
                    CreateEnemyKnight();
                    break;
                case "EnemyDemonConfig":
                    CreateEnemyDemon();
                    break;
            }
        
            yield return new WaitForSeconds(enemy.EnemySpawnRate);
        }
    }
}
