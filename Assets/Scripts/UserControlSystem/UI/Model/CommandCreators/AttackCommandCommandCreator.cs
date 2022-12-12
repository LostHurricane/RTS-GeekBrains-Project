using System;

namespace Commands
{
    public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            creationCallback?.Invoke(new AttackCommand(null));
        }
    }
}