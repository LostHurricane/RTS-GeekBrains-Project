using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceUnitComandExecutor : CommandExecutorBase<IProduceUnitCommand>
{
    [SerializeField] private Transform _unitsParent;

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        Instantiate(command.UnitPrefab,
            new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
            Quaternion.identity,
            _unitsParent);
    }
}
