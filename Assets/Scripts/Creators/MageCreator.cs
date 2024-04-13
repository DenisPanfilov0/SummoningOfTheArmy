using UnityEngine;

public class MageCreator : AllyCreator
{
    public override AllyUnit FactoryMethod()
    {
        var prefab = Resources.Load<GameObject>("Mage");
        var go = GameObject.Instantiate(prefab);
        var unitComponent = go.AddComponent<Mage>();
        unitComponent.Init(0, 0, 0, 0);
        return (Mage)unitComponent;
    }
}