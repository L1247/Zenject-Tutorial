#region

using Zenject;

#endregion

namespace Script
{
    public class PlayerController : ITickable
    {
    #region Private Variables

        [Inject]
        private ICharacter characterController;

        [Inject]
        private IInputSystem inputSystemManager;

    #endregion

    #region Public Methods

        public void Tick()
        {
            if (inputSystemManager.IsDashKeyDown())
                characterController.DoDash(3 , 10);
            else
                Walk();
        }

        public void Walk()
        {
            var horizontalValue = inputSystemManager.GetHorizontalValue();
            characterController.Walk(horizontalValue);
        }

    #endregion
    }
}