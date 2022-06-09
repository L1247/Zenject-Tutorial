#region

using UnityEngine;
using Zenject;

#endregion

namespace Script
{
    public interface IMove
    {
    #region Public Methods

        void DoDash(int horizontalValue , int frame);

        void Walk(int horizontalValue);

    #endregion
    }

    public interface ICharacter : IMove { }

    public enum MovingState
    {
        Idle , Walk , Dash
    }

    public class CharacterController_CSharp : ICharacter , ITickable
    {
    #region Public Variables

        public MovingState CurrentMovingState { get; private set; }

    #endregion

    #region Private Variables

        [Inject(Id = "MainPlayer")]
        private Transform mainCharacter;

        private readonly float moveSpeed;

        [Inject]
        private ITimeSystem timeSystem;

        private int dashHorizontalValue;
        private int dashFrame;

    #endregion

    #region Constructor

        public CharacterController_CSharp()
        {
            moveSpeed = 5;
        }

    #endregion

    #region Public Methods

        public void DoDash(int horizontalValue , int frame)
        {
            dashFrame           = frame;
            dashHorizontalValue = horizontalValue;
            CurrentMovingState  = MovingState.Dash;
        }

        public void HorizontalMove(int horizontalValue)
        {
            var deltaTime   = timeSystem.GetDeltaTime();
            var newPosition = Vector3.right * (horizontalValue * deltaTime) * moveSpeed;
            mainCharacter.position += newPosition;
        }

        public void Tick()
        {
            TickDash();
        }

        public void Walk(int horizontalValue)
        {
            if (CurrentMovingState == MovingState.Dash)
                return;
            HorizontalMove(horizontalValue);
            CurrentMovingState = MovingState.Walk;
        }

    #endregion

    #region Private Methods

        private void TickDash()
        {
            if (CurrentMovingState == MovingState.Dash)
            {
                dashFrame -= 1;
                if (dashFrame == 0) CurrentMovingState = MovingState.Idle;
                HorizontalMove(dashHorizontalValue);
            }
        }

    #endregion
    }
}