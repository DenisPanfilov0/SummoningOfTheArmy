using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCreator
{
    protected UnitConfig _unitConfig;
    
    public abstract EnemyUnit FactoryMethod(Transform parent);
}
