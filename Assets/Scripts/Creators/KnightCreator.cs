using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

public class KnightCreator : UnitCreator
{
    public KnightCreator(UnitConfig knightConfig)
    {
        _unitConfig = knightConfig;
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

    public override EnemyUnit FactoryMethodEnemy(string path, Transform parent)
    {
        var assetProvider = new AssetProvider();
        var go = assetProvider.Instantiate(path, parent);
        var unitComponent = go.AddComponent<EnemyUnit>();
        unitComponent.Init(_unitConfig.Health, _unitConfig.MovementSpeed, _unitConfig.Damage, _unitConfig.AttackSpeed, _unitConfig.AttackRadius);
        
        var circleCollider = go.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.radius = _unitConfig.AttackRadius;
        }
        return unitComponent;
    }
}