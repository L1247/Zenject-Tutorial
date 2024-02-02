#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer3.Scripts
{
    public class ShipInputHandler : ITickable
    {
    #region Private Variables

        private readonly Transform _transform;
        private readonly float     _speed;

    #endregion

    #region Constructor

        public ShipInputHandler(
                float     speed ,
                Transform transform)
        {
            _transform = transform;
            _speed     = speed;
        }

    #endregion

    #region Public Methods

        public void Tick()
        {
            if (Input.GetKey(KeyCode.UpArrow)) _transform.position += Vector3.forward * _speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.DownArrow)) _transform.position -= Vector3.forward * _speed * Time.deltaTime;
        }

    #endregion
    }
}