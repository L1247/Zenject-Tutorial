#region

using UnityEngine;

#endregion

namespace Zenject.SpaceFighter
{
    public class PlayerFacade : MonoBehaviour
    {
    #region Public Variables

        public bool IsDead => _model.IsDead;

        public Quaternion Rotation => _model.Rotation;

        public Vector3 Position => _model.Position;

    #endregion

    #region Private Variables

        private Player      _model;
        PlayerDamageHandler _hitHandler;

    #endregion

    #region Public Methods

        [Inject]
        public void Construct(Player player , PlayerDamageHandler hitHandler)
        {
            _model      = player;
            _hitHandler = hitHandler;
        }

        public void TakeDamage(Vector3 moveDirection)
        {
            _hitHandler.TakeDamage(moveDirection);
        }

    #endregion
    }
}