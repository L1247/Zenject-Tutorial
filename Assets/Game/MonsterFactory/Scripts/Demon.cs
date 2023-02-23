#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class Demon : MonoBehaviour , IEnemy , IPoolable<IMemoryPool>
    {
    #region Public Methods

        [Inject]
        public void Construct(RandomValue randomValue)
        {
            Debug.Log($"{randomValue.Value}");
        }

        public void OnDespawned()             { }
        public void OnSpawned(IMemoryPool p1) { }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<Demon> { }

    #endregion
    }
}