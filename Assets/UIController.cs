using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Config;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform _allyPrefabSpawnPosition;
    [SerializeField] private Transform _enemyPrefabSpawnPosition;
    [SerializeField] private List<UnitConfig> _configs;
    [SerializeField] private MainPlayerConfig _mainPlayer;
    
    private LevelConfig _levelConfig;

    public void InitSpawnPoint(Transform heroSpawn, Transform enemySpawn, LevelConfig levelConfig,
        MainPlayerConfig mainPlayer)
    {
        _allyPrefabSpawnPosition = heroSpawn;
        _enemyPrefabSpawnPosition = enemySpawn;
        _levelConfig = levelConfig;
        _mainPlayer = mainPlayer;
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
        UnitConfig mageConfig = Resources.Load<UnitConfig>("Configs/Units/MageConfig");
        mageConfig.LoadData(mageConfig.name);
        string path = "Prefabs/AllyUnits/MagePrefab";
        UnitCreator creator = new MageCreator(mageConfig);
        AllyUnit mageUnit = (AllyUnit)creator.FactoryMethodAlly(path, _allyPrefabSpawnPosition);
    }

    private void CreateKnight()
    {
        var knightConfig = Resources.Load<UnitConfig>("Configs/Units/KnightConfig");
        knightConfig.LoadData(knightConfig.name);
        string path = "Prefabs/AllyUnits/KnightPrefab";
        UnitCreator creator = new KnightCreator(knightConfig);
        AllyUnit knightUnit = (AllyUnit)creator.FactoryMethodAlly(path ,_allyPrefabSpawnPosition);
    }

    private void CreateDemon()
    {
        var demonConfig = Resources.Load<UnitConfig>("Configs/Units/DemonConfig");
        demonConfig.LoadData(demonConfig.name);
        string path = "Prefabs/AllyUnits/DemonPrefab";
        UnitCreator creator = new DemonCreator(demonConfig);
        AllyUnit demonUnit = (AllyUnit)creator.FactoryMethodAlly(path, _allyPrefabSpawnPosition);
    }


    private void CreateEnemyMage(float enemyReward)
    {
        var mageConfig = Resources.Load<UnitConfig>("Configs/Enemy/EnemyMageConfig");
        mageConfig.LoadData(mageConfig.name);
        string path = "Prefabs/Enemy/EnemyMagePrefab";
        UnitCreator creator = new MageCreator(mageConfig);
        EnemyUnit mageUnit = (EnemyUnit)creator.FactoryMethodEnemy(path, _enemyPrefabSpawnPosition, enemyReward, _mainPlayer);
    }

    private void CreateEnemyKnight(float enemyReward)
    {
        var knightConfig = Resources.Load<UnitConfig>("Configs/Enemy/EnemyKnightConfig");
        knightConfig.LoadData(knightConfig.name);
        string path = "Prefabs/Enemy/EnemyKnightPrefab";
        UnitCreator creator = new KnightCreator(knightConfig);
        EnemyUnit knightUnit = (EnemyUnit)creator.FactoryMethodEnemy(path, _enemyPrefabSpawnPosition, enemyReward, _mainPlayer);
    }
    
    private void CreateEnemyDemon(float enemyReward)
    {
        var demonConfig = Resources.Load<UnitConfig>("Configs/Enemy/EnemyDemonConfig");
        demonConfig.LoadData(demonConfig.name);
        string path = "Prefabs/Enemy/EnemyDemonPrefab";
        UnitCreator creator = new DemonCreator(demonConfig);
        EnemyUnit demonUnit = (EnemyUnit)creator.FactoryMethodEnemy(path, _enemyPrefabSpawnPosition, enemyReward, _mainPlayer);
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
                    CreateEnemyMage(enemy.EnemyReward);
                    break;
                case "EnemyKnightConfig":
                    CreateEnemyKnight(enemy.EnemyReward);
                    break;
                case "EnemyDemonConfig":
                    CreateEnemyDemon(enemy.EnemyReward);
                    break;
            }
        
            yield return new WaitForSeconds(enemy.EnemySpawnRate);
        }
    }
}
