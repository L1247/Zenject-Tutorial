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

        private IMemoryPool                 pool;
        private StateMachineProviderFactory stateMachineProviderFactory;
        private MonsterNameProvider         monsterNameProvider;
        private MonsterData                 monsterData;
        private IFSMProvider                fsmProvider;
        private string                      fsm;

    #endregion

    #region Public Methods

        [Inject]
        public void Construct(MonsterNameProvider monsterNameProvider , IFSMProvider fsmProvider , MonsterData monsterData)
        {
            this.fsmProvider         = fsmProvider;
            this.monsterData         = monsterData;
            this.monsterNameProvider = monsterNameProvider;
            Debug.Log("Construct");
        }

        public void Dispose()
        {
            pool.Despawn(this);
        }

        public bool HasState(string stateName)
        {
            return fsm == stateName;
        }

        public void Init(int monsterType)
        {
            Debug.Log($"init: monsterType - {monsterType}");
            gameObject.name = monsterNameProvider.GetName(monsterType);
            fsm             = fsmProvider.GetFsm(monsterType);
            Debug.Log($"{fsm}");
        }

        public void OnDespawned()
        {
            pool            = null;
            gameObject.name = "Monster";
        }

        public void OnSpawned(MonsterData monsterData , IMemoryPool pool)
        {
            this.pool = pool;
            this.monsterData.CopyPropertiesFromThis(monsterData);
            Debug.Log("Clone completed");
            var monsterType = monsterData.Type;
            Init(monsterType);
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<MonsterData , Monster> { }

    #endregion
    }
}