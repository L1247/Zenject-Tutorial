#region

using UnityEngine;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class RandomValue
    {
    #region Public Variables

        public float Value { get; }

    #endregion

    #region Constructor

        public RandomValue()
        {
            Value = Random.Range(0 , 100);
        }

    #endregion
    }
}