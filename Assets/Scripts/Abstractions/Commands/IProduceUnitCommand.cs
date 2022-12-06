using UnityEngine;

namespace Commands
{
    public interface IProduceUnitCommand: ICommand
    {
        GameObject UnitPrefab { get; }
    }
}