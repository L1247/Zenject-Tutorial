#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public class State1
    {
    #region Private Variables

        private readonly MonsterData monsterData;

    #endregion

    #region Constructor

        public State1(MonsterData monsterData)
        {
            this.monsterData = monsterData;
            Debug.Log($"state1: {this.monsterData.Type}");
        }

    #endregion

    #region Public Methods

        public void LogDataType()
        {
            Debug.Log($"state1: {monsterData.Type}");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<State1> { }

    #endregion
    }
}