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
        private StateMachineFactory stateMachineFactory;
        private MonsterData         monsterData;

    #endregion

    #region Public Methods

        [Inject]
        public void Construct(
                MonsterNameProvider monsterNameProvider , StateMachineFactory stateMachineFactory , MonsterData monsterData)
        {
            this.monsterData         = monsterData;
            this.stateMachineFactory = stateMachineFactory;
            this.monsterNameProvider = monsterNameProvider;
            Debug.Log("Construct");
        }

        public void Dispose()
        {
            pool.Despawn(this);
        }

        public void OnDespawned()
        {
            pool            = null;
            gameObject.name = "Monster";
        }

        public void OnSpawned(MonsterData monsterData , IMemoryPool pool)
        {
            this.pool = pool;
            this.monsterData.CloneFromThis(monsterData);
            Debug.Log("Clone completed");
            var monsterType = monsterData.Type;
            Init(monsterType);
        }

    #endregion

    #region Private Methods

        private void Init(int monsterType)
        {
            Debug.Log($"init: monsterType - {monsterType}");
            gameObject.name = monsterNameProvider.GetName(monsterType);
            var stateMachine = stateMachineFactory.Create(monsterType);
            Debug.Log($"init: {stateMachine}");
            var fsm = stateMachine.GetFSM();
            Debug.Log($"{fsm}");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<MonsterData , Monster> { }

    #endregion
    }
}