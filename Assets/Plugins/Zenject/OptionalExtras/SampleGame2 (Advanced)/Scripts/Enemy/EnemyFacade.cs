#region

using System;
using UnityEngine;

#endregion

namespace Zenject.SpaceFighter
{
    // Here we can add some high-level methods to give some info to other
    // parts of the codebase outside of our enemy facade
    public class EnemyFacade : MonoBehaviour , IPoolable<float , float , IMemoryPool> , IDisposable
    {
    #region Public Variables

        public EnemyStates State => _stateManager.CurrentState;

        public float Accuracy => _tunables.Accuracy;

        public float Speed => _tunables.Speed;

        public Vector3 Position
        {
            get => _view.Position;
            set => _view.Position = value;
        }

    #endregion

    #region Private Variables

        private EnemyView     _view;
        private EnemyTunables _tunables;
        EnemyDeathHandler     _deathHandler;
        EnemyStateManager     _stateManager;
        private EnemyRegistry _registry;
        private IMemoryPool   _pool;

    #endregion

    #region Public Methods

        [Inject]
        public void Construct(
                EnemyView         view ,
                EnemyTunables     tunables ,
                EnemyDeathHandler deathHandler ,
                EnemyStateManager stateManager ,
                EnemyRegistry     registry)
        {
            _view         = view;
            _tunables     = tunables;
            _deathHandler = deathHandler;
            _stateManager = stateManager;
            _registry     = registry;
        }

        public void Die()
        {
            _deathHandler.Die();
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            _registry.RemoveEnemy(this);
            _pool = null;
        }

        public void OnSpawned(float accuracy , float speed , IMemoryPool pool)
        {
            _pool              = pool;
            _tunables.Accuracy = accuracy;
            _tunables.Speed    = speed;

            _registry.AddEnemy(this);
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<float , float , EnemyFacade> { }

    #endregion
    }
}