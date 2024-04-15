using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyCreator
{
    protected UnitConfig _unitConfig;

    public abstract AllyUnit FactoryMethod(Transform parent);
}
