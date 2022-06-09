#region

using UnityEngine;
using Zenject;

#endregion

namespace Script
{
    public interface IMove
    {
    #region Public Methods

        void Dash(int value);

        void Walk(int horizontalValue);

    #endregion
    }

    public interface ICharacter : IMove
    {
    #region Public Variables

        CharacterState State { get; }

    #endregion
    }

    public enum CharacterState
    {
        Idle , Walk , Dash
    }

    public class CharacterController_CSharp : ICharacter , ITickable
    {
    #region Public Variables

        public CharacterState State { get; private set; }

    #endregion

    #region Private Variables

        [Inject(Id = "MainPlayer")]
        private Transform mainCharacter;

        private readonly float moveSpeed;

        [Inject]
        private ITimeSystem timeSystem;

        private int dashHorizontalValue;
        private int dashFrame = 5;

    #endregion

    #region Constructor

        public CharacterController_CSharp()
        {
            moveSpeed = 5;
        }

    #endregion

    #region Public Methods

        public void Dash(int value)
        {
            dashHorizontalValue = value;
            State               = CharacterState.Dash;
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
            HorizontalMove(horizontalValue);
            State = CharacterState.Walk;
        }

    #endregion

    #region Private Methods

        private void TickDash()
        {
            if (State == CharacterState.Dash)
            {
                dashFrame -= 1;
                if (dashFrame == 0) State = CharacterState.Idle;
                HorizontalMove(dashHorizontalValue);
            }
        }

    #endregion
    }
}