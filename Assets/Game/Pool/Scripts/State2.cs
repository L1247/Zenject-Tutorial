#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public class State2
    {
    #region Constructor

        public State2(Monster monster)
        {
            Debug.Log($"state2: {monster}");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<State2> { }

    #endregion
    }
}