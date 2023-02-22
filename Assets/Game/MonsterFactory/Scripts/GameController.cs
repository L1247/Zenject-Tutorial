#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class GameController : IInitializable , ITickable
    {
    #region Private Variables

        private readonly EnemyFactory      _enemyFactory;
        private readonly DifficultyManager difficultyManager;

    #endregion

    #region Constructor

        public GameController(EnemyFactory enemyFactory , DifficultyManager difficultyManager)
        {
            _enemyFactory          = enemyFactory;
            this.difficultyManager = difficultyManager;
        }

    #endregion

    #region Public Methods

        public void Initialize()
        {
            var enemy = _enemyFactory.Create();
            Debug.Log($"{enemy}");
            // ...
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var difficulty = difficultyManager.Difficulty;
                difficultyManager.Difficulty = difficulty == Difficulties.Easy ? Difficulties.Hard : Difficulties.Easy;
                var enemy = _enemyFactory.Create();
                Debug.Log($"{enemy}");
            }
        }

    #endregion
    }
}