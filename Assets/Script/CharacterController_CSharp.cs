using UnityEngine;
using Zenject;

namespace Script
{
    public class CharacterController_CSharp : ITickable
    {
    #region Private Variables

        [Inject]
        private IInputSystem inputSystemManager;

        [Inject(Id = "MainPlayer")]
        private Transform mainCharacter;

        private readonly float       moveSpeed;

        [Inject]
        private ITimeSystem timeSystem;

    #endregion

    #region Constructor

        public CharacterController_CSharp()
        {
            moveSpeed  = 5;
        }

    #endregion

    #region Public Methods

        public void Tick()
        {
            var horizontalValue = inputSystemManager.GetHorizontalValue();
            HorizontalMove(horizontalValue);
        }

    #endregion

    #region Private Methods

        private void HorizontalMove(int horizontalValue)
        {
            var deltaTime   = timeSystem.GetDeltaTime();
            var newPosition = Vector3.right * (horizontalValue * deltaTime) * moveSpeed;
            mainCharacter.position += newPosition;
        }

    #endregion
    }
}