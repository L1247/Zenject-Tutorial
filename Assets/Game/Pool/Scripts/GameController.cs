#region

using System.Collections.Generic;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public class GameController : IInitializable , ITickable
    {
    #region Private Variables

        private readonly Monster.Factory monsterFactory;
        private readonly List<Monster>   monsters = new List<Monster>();

    #endregion

    #region Constructor

        public GameController(Monster.Factory monsterFactory)
        {
            this.monsterFactory = monsterFactory;
        }

    #endregion

    #region Public Methods

        public void Initialize()
        {
            CreateMonster();
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space)) CreateMonster();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                foreach (var monster in monsters) monster.Dispose();
                monsters.Clear();
            }
        }

    #endregion

    #region Private Methods

        private void CreateMonster()
        {
            var monsterData = new MonsterData(Random.Range(1 , 4));
            var monster     = monsterFactory.Create(monsterData);
            monsters.Add(monster);
        }

    #endregion
    }
}