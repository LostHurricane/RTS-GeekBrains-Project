using Commands;
using System.Threading.Tasks;
using UnityEngine;

public class PatrolComandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Patrol comand executed");
    }
}
