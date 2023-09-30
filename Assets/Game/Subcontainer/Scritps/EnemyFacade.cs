#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer.Scritps
{
    public class EnemyFacade
    {
    #region Constructor

        public EnemyFacade(ValueProvider valueProvider)
        {
            Debug.Log($"EnemyFacade: {valueProvider.Value}");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<EnemyFacade> { }

    #endregion
    }
}