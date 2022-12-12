using System;

namespace Commands
{
    public class PatrolCommandCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            creationCallback?.Invoke(new PatrolCommand());
        }
    }
}