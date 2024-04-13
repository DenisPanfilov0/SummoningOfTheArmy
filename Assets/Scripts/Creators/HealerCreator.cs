using UnityEngine;

public class HealerCreator : AllyCreator
{
    public override AllyUnit FactoryMethod(Transform parent)
    {
        var prefab = Resources.Load<GameObject>("/*путь до префаба объекта*/");
        var go = GameObject.Instantiate(prefab, parent);
        var unitComponent = go.AddComponent<Healer>();
        unitComponent.Init(0, 0, 0);
        return unitComponent;
    }
}