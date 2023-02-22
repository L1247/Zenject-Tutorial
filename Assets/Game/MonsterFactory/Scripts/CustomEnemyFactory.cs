#region

using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class CustomEnemyFactory : IFactory<IEnemy>
    {
    #region Private Variables

        private readonly DifficultyManager _difficultyManager;
        private readonly Dog.Factory       dogFactory;
        private readonly Demon.Factory     demonFactory;

    #endregion

    #region Constructor

        public CustomEnemyFactory(DifficultyManager difficultyManager , Dog.Factory dogFactory , Demon.Factory demonFactory)
        {
            _difficultyManager = difficultyManager;
            this.dogFactory    = dogFactory;
            this.demonFactory  = demonFactory;
        }

    #endregion

    #region Public Methods

        public IEnemy Create()
        {
            return _difficultyManager.Difficulty == Difficulties.Hard
                    ? dogFactory.Create()
                    : demonFactory.Create();
        }

    #endregion
    }
}