using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Chomper")] private GameObject _unitPrefab;

    public ProduceUnitCommand(GameObject unitPrefab)
    {
        _unitPrefab = unitPrefab;
    }

    public ProduceUnitCommand()
    {
    }
}

public class ProduceUnitCommandHeir : ProduceUnitCommand
{

}
