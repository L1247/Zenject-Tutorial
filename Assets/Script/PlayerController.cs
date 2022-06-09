#region

using Zenject;

#endregion

namespace Script
{
    public class PlayerController : ITickable
    {
    #region Private Variables

        [Inject]
        private ICharacterService service;

        [Inject]
        private IInputSystem inputSystemManager;

    #endregion

    #region Public Methods

        public void Tick()
        {
            // if (inputSystemManager.IsDashKeyDown())
            //     characterController.DoDash(10 , 10);
            // else

            DoWalk();
        }

    #endregion

    #region Private Methods

        private void DoWalk()
        {
            var horizontalValue = inputSystemManager.GetHorizontalValue();
            var canWalk         = horizontalValue != 0;
            if (canWalk) service.Walk(horizontalValue);
        }

    #endregion
    }
}