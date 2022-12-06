using Abstractions;
using Commands;

public class AttackCommand : IAttackCommand
{
    public ISelectable Target => _target;
    private ISelectable _target;

    public AttackCommand(ISelectable target)
    {
        _target = target;
    }
}
