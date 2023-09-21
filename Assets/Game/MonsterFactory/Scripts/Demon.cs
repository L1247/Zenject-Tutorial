#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class Demon : MonoBehaviour , IEnemy 
    {
    #region Public Methods

        [Inject]
        public void Construct(int a, RandomValue randomValue)
        {
            Debug.Log($"{a}");
            Debug.Log($"RandomValue: {randomValue.Value}");
            transform.position = Random.insideUnitCircle * 3;
        }

        public void OnDespawned() { }

        public void OnSpawned(int a , IMemoryPool p1)
        {
            Debug.Log($"{a}");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<int , Demon> { }

    #endregion
    }
}