using Abstractions;
using Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;
    private ISelectable _currentSelectable;
    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);

        _view.OnClick += onButtonClick;
    }

    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }
    private void onButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
            return;
        }

        var mover = commandExecutor as CommandExecutorBase<IMoveCommand>;
        if (mover != null)
        {
            mover.ExecuteSpecificCommand(new MoveCommand(Vector3.zero));
            return;
        }

        var attacker = commandExecutor as CommandExecutorBase<IAttackCommand>;
        if (attacker != null)
        {
            attacker.ExecuteSpecificCommand(new AttackCommand(null));
            return;
        }

        var patroller = commandExecutor as CommandExecutorBase<IPatrolCommand>;
        if (patroller != null)
        {
            patroller.ExecuteSpecificCommand(new PatrolCommand());
            return;
        }

        var stopper = commandExecutor as CommandExecutorBase<IStopCommand>;
        if (stopper != null)
        {
            stopper.ExecuteSpecificCommand(new StopCommand());
            return;
        }

        throw new
        ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}:Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
    
    
    
    }
}
