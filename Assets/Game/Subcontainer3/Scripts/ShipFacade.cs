#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer3.Scripts
{
    public class ShipFacade
    {
    #region Public Variables

        [Inject]
        public Transform Transform { get; private set; }

    #endregion

    #region Private Variables

        private readonly ShipHealthHandler _healthHandler;

    #endregion

    #region Constructor

        public ShipFacade(ShipHealthHandler healthHandler)
        {
            _healthHandler = healthHandler;
        }

    #endregion

    #region Public Methods

        public void TakeDamage(float damage)
        {
            _healthHandler.TakeDamage(damage);
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<float , ShipFacade> { }

    #endregion
    }
}