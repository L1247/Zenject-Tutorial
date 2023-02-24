namespace Game.Pool.Scripts
{
    public class StateMachineProvider
    {
    #region Private Variables

        private readonly StateMachine1 stateMachine1;
        private readonly StateMachine2 stateMachine2;

    #endregion

    #region Constructor

        public StateMachineProvider(StateMachine1 stateMachine1 , StateMachine2 stateMachine2)
        {
            this.stateMachine2 = stateMachine2;
            this.stateMachine1 = stateMachine1;
        }

    #endregion

    #region Public Methods

        public IStateMachine GetFSM(int monsterType)
        {
            return monsterType switch
            {
                1 => stateMachine1 , 2 => stateMachine2 , _ => null
            };
        }

    #endregion
    }
}