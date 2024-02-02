#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer3.Scripts
{
    public class GameRunner : ITickable
    {
    #region Private Variables

        private readonly ShipFacade.Factory _shipFactory;

        private Vector3 lastShipPosition;

    #endregion

    #region Constructor

        public GameRunner(ShipFacade.Factory shipFactory)
        {
            _shipFactory = shipFactory;
        }

    #endregion

    #region Public Methods

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var ship = _shipFactory.Create(Random.Range(2.0f , 20.0f));
                ship.Transform.position = lastShipPosition;

                lastShipPosition += Vector3.forward * 2;
            }
        }

    #endregion
    }
}