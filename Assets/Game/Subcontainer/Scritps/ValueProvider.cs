#region

using UnityEngine;

#endregion

namespace Game.Subcontainer.Scritps
{
    public class ValueProvider
    {
    #region Public Variables

        public int Value { get; }

    #endregion

    #region Constructor

        public ValueProvider()
        {
            Value = Random.Range(0 , 999);
        }

    #endregion
    }
}