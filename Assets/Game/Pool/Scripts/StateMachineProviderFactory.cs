#region

using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public class StateMachineProviderFactory : PlaceholderFactory<int , IStateMachineProvider>
    {
    #region Public Methods

        public IStateMachineProvider CreateProvider(int monsterType)
        {
            return Create(monsterType);
        }

    #endregion
    }
}