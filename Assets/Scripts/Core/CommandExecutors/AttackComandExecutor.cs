using Commands;
using System.Threading.Tasks;
using UnityEngine;

public class AttackComandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"Attack comand executed");
    }
}
