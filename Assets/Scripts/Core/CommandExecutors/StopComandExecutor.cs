using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class StopComandExecutor : CommandExecutorBase<IStopCommand>
{
    public CancellationTokenSource CancellationTokenSource { get; set; }

    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        CancellationTokenSource?.Cancel();
    }
}
