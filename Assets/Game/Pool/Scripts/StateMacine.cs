#region

using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public interface IStateMachineFactory
    {
    #region Public Methods

        string GetFSM();

    #endregion
    }

    public class StateMachine2 : IStateMachineFactory
    {
    #region Private Variables

        private readonly State1.Factory state1Factory;
        private readonly State2.Factory state2Factory;

    #endregion

    #region Constructor

        public StateMachine2(State1.Factory state1Factory , State2.Factory state2Factory)
        {
            this.state2Factory = state2Factory;
            this.state1Factory = state1Factory;
        }

    #endregion

    #region Public Methods

        public string GetFSM()
        {
            return $"{state1Factory.Create()} , {state2Factory.Create()}";
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<StateMachine2> { }

    #endregion
    }

    public class StateMachine1 : IStateMachineFactory
    {
    #region Private Variables

        private readonly State1.Factory state1Factory;

    #endregion

    #region Constructor

        public StateMachine1(State1.Factory state1Factory)
        {
            this.state1Factory = state1Factory;
        }

    #endregion

    #region Public Methods

        public string GetFSM()
        {
            return $"{state1Factory.Create()}";
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<StateMachine1> { }

    #endregion
    }
}