using Commands;
using UnityEngine;

public class PatrolComandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Patrol comand executed");
    }
}
