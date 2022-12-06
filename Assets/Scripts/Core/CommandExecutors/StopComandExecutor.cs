using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopComandExecutor : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"Stop comand executed");
    }
}
