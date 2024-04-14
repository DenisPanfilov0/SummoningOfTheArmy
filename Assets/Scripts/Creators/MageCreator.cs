using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

public class MageCreator : AllyCreator
{
    public override AllyUnit FactoryMethod(Transform parent)
    {
        var assetProvider = new AssetProvider();
        var go = assetProvider.Instantiate("Prefabs/MagePrefab", parent);
        var unitComponent = go.AddComponent<MageUnit>();
        unitComponent.Init(100, 25, 15, 0);
        return unitComponent;
    }
}