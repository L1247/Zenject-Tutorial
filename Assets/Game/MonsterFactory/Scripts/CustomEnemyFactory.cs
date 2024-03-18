#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class CustomEnemyFactory : PlaceholderFactory<IEnemy> , IValidatable , IEnemyFactory
            // FactoryCustomInterface
            // public class CustomEnemyFactory : EnemyFactory , IValidatable 
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

        public override IEnemy Create()
        {
            IEnemy enemy = _difficultyManager.Difficulty == Difficulties.Hard
                                   ? demonFactory.Create(1)
                                   : dogFactory.Create();
            return enemy;
        }

        public override void Validate()
        {
            Debug.Log("Validate Factory");
            dogFactory.Create();
            demonFactory.Create(1);
        }

    #endregion
    }
}