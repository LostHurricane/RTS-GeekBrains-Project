using Commands;
using UnityEngine;

public class AttackComandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"Attack comand executed");
    }
}
