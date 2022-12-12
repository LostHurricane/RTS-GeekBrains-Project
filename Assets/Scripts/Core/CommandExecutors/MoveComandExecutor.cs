using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComandExecutor : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log($"{name} is moving to {command.Target}!");
    }
}
