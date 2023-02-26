namespace Game.Pool.Scripts
{
    public interface IFSMProvider
    {
    #region Public Methods

        IStateMachineProvider GetFsm(int monsterType);

    #endregion
    }

    public class FSMProvider : IFSMProvider
    {
    #region Private Variables

        private readonly StateMachineProviderFactory stateMachineProviderFactory;

    #endregion

    #region Constructor

        public FSMProvider(StateMachineProviderFactory stateMachineProviderFactory)
        {
            this.stateMachineProviderFactory = stateMachineProviderFactory;
        }

    #endregion

    #region Public Methods

        public IStateMachineProvider GetFsm(int monsterType)
        {
            var stateMachine = stateMachineProviderFactory.Create(monsterType);
            return stateMachine;
        }

    #endregion
    }
}