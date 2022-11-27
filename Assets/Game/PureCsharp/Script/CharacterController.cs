#region

using UnityEngine;
using Zenject;

#endregion

namespace PureCsharp.Core
{
    public interface IMove
    {
    #region Public Methods

        void Dash(int value);

        void Walk(int horizontalValue);

    #endregion

        float MoveSpeed { get; }
        void  HorizontalMove(int horizontalValue);
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

    public class CharacterController : ICharacter , ITickable
    {
    #region Public Variables

        public readonly int defaultDashFrame = 5;

        public CharacterState State { get; private set; }

        [Inject(Id = "MoveSpeed")]
        public float MoveSpeed { get; private set; }
        
    #endregion

    #region Private Variables

        [Inject(Id = "MainPlayer")]
        private Transform mainCharacter;

        [Inject]
        private ITimeSystem timeSystem;

        private int dashHorizontalValue;
        private int dashFrame;

    #endregion

    #region Public Methods

        public void Dash(int value)
        {
            dashFrame           = defaultDashFrame;
            dashHorizontalValue = value;
            State               = CharacterState.Dash;
        }

        public void HorizontalMove(int horizontalValue)
        {
            Debug.Log($"{MoveSpeed}");
            var deltaTime   = timeSystem.GetDeltaTime();
            var newPosition = Vector3.right * (horizontalValue * deltaTime) * MoveSpeed;
            mainCharacter.position += newPosition;
        }

        public void Tick()
        {
            TickDash();
        }

        public void Walk(int horizontalValue)
        {
            if (horizontalValue == 0)
            {
                State = CharacterState.Idle;
                return;
            }

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