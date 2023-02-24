#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public class State1
    {
    #region Constructor

        public State1(Monster monster)
        {
            Debug.Log($"state1: {monster}");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<State1> { }

    #endregion
    }
}