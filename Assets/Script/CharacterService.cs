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
            // 條件: 角色狀態是Walk
            var isStateNotWalk = character.State != CharacterState.Walk;
            if (isStateNotWalk) return;
            character.Dash(dashValue);
        }

        public void Walk(int right)
        {
            character.Walk(right);
        }

    #endregion
    }
}