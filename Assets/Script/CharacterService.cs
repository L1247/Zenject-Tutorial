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
            character.Dash(dashValue);
        }

        public void Walk(int right)
        {
            character.Walk(right);
        }

    #endregion
    }
}