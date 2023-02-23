#region

using System;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public class Monster : MonoBehaviour , IPoolable<MonsterData , IMemoryPool> , IDisposable
    {
    #region Private Variables

        private IMemoryPool         pool;
        private MonsterNameProvider monsterNameProvider;

    #endregion

    #region Public Methods

        [Inject]
        public void Construct(MonsterNameProvider monsterNameProvider)
        {
            this.monsterNameProvider = monsterNameProvider;
            Debug.Log("Construct");
        }

        public void Dispose()
        {
            pool.Despawn(this);
        }

        public void Init(int monsterType)
        {
            Debug.Log($"{monsterType}");
            gameObject.name = monsterNameProvider.GetName(monsterType);
        }

        public void OnDespawned()
        {
            pool            = null;
            gameObject.name = "Monster";
        }

        public void OnSpawned(MonsterData monsterData , IMemoryPool pool)
        {
            this.pool = pool;
            var monsterType = monsterData.Type;
            Init(monsterType);
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<MonsterData , Monster> { }

    #endregion
    }
}