#region

using Zenject;

#endregion

namespace Script
{
    public interface ICharacterService
    {
    #region Public Methods

        void Walk(int right);

    #endregion
    }


    public class CharacterService : ICharacterService
    {
    #region Private Variables

        [Inject]
        private ICharacter character;

    #endregion

    #region Public Methods

        public void Walk(int right)
        {
            character.Walk(right);
        }

    #endregion
    }
}