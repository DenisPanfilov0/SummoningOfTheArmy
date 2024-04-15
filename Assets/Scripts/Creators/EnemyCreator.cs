using System.Collections;
using System.Collections.Generic;
using CodeBase.Config;
using UnityEngine;

public abstract class UnitCreator
{
    protected UnitConfig _unitConfig;
    
    public abstract AllyUnit FactoryMethodAlly(string path, Transform parent);
    
    public abstract EnemyUnit FactoryMethodEnemy(string path, Transform parent, float enemyReward,
        MainPlayerConfig mainPlayer);
}
