using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

public class DemonCreator : EnemyCreator
{
    public DemonCreator(UnitConfig demonConfig)
    {
        _unitConfig = demonConfig;
    }

    public override EnemyUnit FactoryMethod(Transform parent)
    {
        var assetProvider = new AssetProvider();
        var go = assetProvider.Instantiate("Prefabs/DemonPrefab", parent);
        var unitComponent = go.AddComponent<DemonUnit>();
        unitComponent.Init(_unitConfig.Health, _unitConfig.MovementSpeed, _unitConfig.Damage, _unitConfig.AttackSpeed, _unitConfig.AttackRadius);
        
        var circleCollider = go.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.radius = _unitConfig.AttackRadius;
        }
        return unitComponent;
    }
}