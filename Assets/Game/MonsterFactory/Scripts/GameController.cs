#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class GameController : IInitializable , ITickable
    {
    #region Private Variables

        // private readonly EnemyFactory enemyFactory;

        private readonly IEnemyFactory     enemyFactory;
        private readonly DifficultyManager difficultyManager;

    #endregion

    #region Constructor

        // public GameController(EnemyFactory enemyFactory , DifficultyManager difficultyManager)
        public GameController(IEnemyFactory enemyFactory , DifficultyManager difficultyManager)
        {
            this.enemyFactory      = enemyFactory;
            this.difficultyManager = difficultyManager;
        }

    #endregion

    #region Public Methods

        public void Initialize()
        {
            var enemy = CreateEnemy();
            Debug.Log($"{enemy}");
            // ...
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var enemy = CreateEnemy();
                Debug.Log($"{enemy}");
            }
        }

    #endregion

    #region Private Methods

        private IEnemy CreateEnemy()
        {
            var difficulty = difficultyManager.Difficulty;
            difficultyManager.Difficulty = difficulty == Difficulties.Easy ? Difficulties.Hard : Difficulties.Easy;
            Debug.Log($"Current difficulty: {difficultyManager.Difficulty}");
            var enemy = enemyFactory.Create();
            return enemy;
        }

    #endregion
    }
}