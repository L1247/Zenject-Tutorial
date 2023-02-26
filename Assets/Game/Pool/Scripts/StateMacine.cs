#region

using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public interface IStateMachineProvider
    {
    #region Public Methods

        string GetFSM();

    #endregion
    }

    public class StateMachine2 : IStateMachineProvider
    {
    #region Private Variables

        private readonly State1.Factory state1Factory;
        private readonly State2.Factory state2Factory;
        private readonly State1         state1;
        private readonly State2         state2;

    #endregion

    #region Constructor

        public StateMachine2(State1.Factory state1Factory , State2.Factory state2Factory)
        {
            this.state2Factory = state2Factory;
            this.state1Factory = state1Factory;
        }

        public StateMachine2(State1 state1 , State2 state2)
        {
            this.state2 = state2;
            this.state1 = state1;
        }

    #endregion

    #region Public Methods

        public string GetFSM()
        {
            var state1 = this.state1 ?? state1Factory.Create();
            var state2 = this.state2 ?? state2Factory.Create();
            state1.LogDataType();
            state2.LogDataType();

            return nameof(state1) + nameof(state2);
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<StateMachine2> { }

    #endregion
    }

    public class StateMachine1 : IStateMachineProvider
    {
    #region Private Variables

        private readonly State1.Factory state1Factory;
        private readonly State1         state1;

    #endregion

    #region Constructor

        public StateMachine1(State1.Factory state1Factory)
        {
            this.state1Factory = state1Factory;
        }

        public StateMachine1(State1 state1)
        {
            this.state1 = state1;
        }

    #endregion

    #region Public Methods

        public string GetFSM()
        {
            var state1 = this.state1 ?? state1Factory.Create();
            state1.LogDataType();
            return nameof(state1);
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<StateMachine1> { }

    #endregion
    }
}