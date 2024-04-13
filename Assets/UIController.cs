using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _createMageButton;
    [SerializeField] private Transform _magePrefabSpawnPosition;

    private void Awake()
    {
        _createMageButton.onClick.AddListener(CreateMage);
    }

    private void CreateMage()
    {
        AllyCreator creator = new MageCreator();
        MageUnit mageUnitUnit = (MageUnit)creator.FactoryMethod(_magePrefabSpawnPosition);
        //mageUnitUnit.Attack();
    }
}
