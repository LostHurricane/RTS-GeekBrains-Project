using Commands;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ProduceUnitComandExecutor : CommandExecutorBase<IProduceUnitCommand>
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private float _productionTime;

    public async override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        await Task.Delay((int)(_productionTime * 1000));
        Instantiate(command.UnitPrefab,
            new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
            Quaternion.identity,
            _unitsParent);
    }
}
