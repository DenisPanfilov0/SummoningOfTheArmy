using CodeBase.Config;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

public class DemonCreator : UnitCreator
{
    public DemonCreator(UnitConfig demonConfig)
    {
        _unitConfig = demonConfig;
    }

    public override AllyUnit FactoryMethodAlly(string path, Transform parent)
    {
        var assetProvider = new AssetProvider();
        var go = assetProvider.Instantiate(path, parent);
        var unitComponent = go.AddComponent<AllyUnit>();
        unitComponent.Init(_unitConfig.Health, _unitConfig.MovementSpeed, _unitConfig.Damage, _unitConfig.AttackSpeed, _unitConfig.AttackRadius);
        
        var circleCollider = go.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.radius = _unitConfig.AttackRadius;
        }
        return unitComponent;
    }
    
    public override EnemyUnit FactoryMethodEnemy(string path, Transform parent, float reward,
        MainPlayerConfig mainPlayer)
    {
        var assetProvider = new AssetProvider();
        var go = assetProvider.Instantiate(path, parent);
        var unitComponent = go.AddComponent<EnemyUnit>();
        var enemyReward = go.AddComponent<EnemyReward>();
        enemyReward.Init(reward, mainPlayer);
        unitComponent.Init(_unitConfig.Health, _unitConfig.MovementSpeed, _unitConfig.Damage, _unitConfig.AttackSpeed, _unitConfig.AttackRadius);
        
        var circleCollider = go.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.radius = _unitConfig.AttackRadius;
        }
        return unitComponent;
    }
}