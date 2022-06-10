#region

using Zenject;

#endregion

namespace Script
{
    public interface ICharacterService
    {
    #region Public Methods

        void Dash();

        void Walk(int right);

    #endregion
    }


    public class CharacterService : ICharacterService
    {
    #region Public Variables

        public readonly int dashValue = 10;

    #endregion

    #region Private Variables

        [Inject]
        private ICharacter character;

    #endregion

    #region Public Methods

        public void Dash()
        {
            // 條件: 角色狀態不是Walk，則不能執行Dash。
            var isStateNotWalk = IsNotState(CharacterState.Walk);
            if (isStateNotWalk) return;
            character.Dash(dashValue);
        }

        public void Walk(int right)
        {
            var isStateDash = IsState(CharacterState.Dash);
            if (isStateDash) return;
            character.Walk(right);
        }

    #endregion

    #region Private Methods

        private bool IsNotState(CharacterState state)
        {
            return character.State != state;
        }

        private bool IsState(CharacterState characterState)
        {
            return character.State == characterState;
        }

    #endregion
    }
}