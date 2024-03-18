#region

using System;
using UnityEngine;

#endregion

namespace Zenject.SpaceFighter
{
    // Responsibilities:
    // - Interpolate rotation of enemy towards the current desired
    // direction
    public class EnemyRotationHandler : IFixedTickable
    {
    #region Public Variables

        public Vector2 DesiredLookDir { get; set; }

    #endregion

    #region Private Variables

        readonly Settings  _settings;
        readonly EnemyView _view;

    #endregion

    #region Constructor

        public EnemyRotationHandler(
                EnemyView view ,
                Settings  settings)
        {
            _settings = settings;
            _view     = view;
        }

    #endregion

    #region Public Methods

        public void FixedTick()
        {
            Debug.Log("FixedTick");
            var lookDir = _view.LookDir;

            var error = Vector3.Angle(lookDir , DesiredLookDir);

            if (Vector3.Cross(lookDir , DesiredLookDir).z < 0)
            {
                error *= -1;
            }

            _view.AddTorque(error * _settings.TurnSpeed);
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Settings
        {
        #region Public Variables

            public float TurnSpeed;

        #endregion
        }

    #endregion
    }
}