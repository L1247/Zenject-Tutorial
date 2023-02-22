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
        public void Construct(RandomValue randomValue)
        {
            Debug.Log($"{randomValue.Value}");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<Demon> { }

    #endregion
    }
}