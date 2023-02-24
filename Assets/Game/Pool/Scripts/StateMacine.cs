#region

using UnityEngine;

#endregion

namespace Game.Pool.Scripts
{
    public interface IStateMachine { }

    public class StateMachine2 : IStateMachine
    {
    #region Constructor

        public StateMachine2(State1 state1 , State2 state2)
        {
            Debug.Log($"StateMachine2: {state1} , {state2}");
        }

    #endregion
    }

    public class StateMachine1 : IStateMachine
    {
    #region Constructor

        public StateMachine1(State1 state1)
        {
            Debug.Log($"StateMachine1: {state1}");
        }

    #endregion
    }
}