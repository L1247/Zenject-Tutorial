#region

using Zenject;

#endregion

namespace Script
{
    public class PlayerController : ITickable
    {
    #region Private Variables

        [Inject]
        private CharacterController_CSharp characterController;

        [Inject]
        private IInputSystem inputSystemManager;

    #endregion

    #region Public Methods

        public void Tick()
        {
            var horizontalValue = inputSystemManager.GetHorizontalValue();
            characterController.HorizontalMove(horizontalValue);
        }

    #endregion
    }
}