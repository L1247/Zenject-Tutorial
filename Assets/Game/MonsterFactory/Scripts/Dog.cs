#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class Dog : MonoBehaviour , IEnemy
    {
    #region Public Methods

        [Inject]
        public void Construct(Player player)
        {
            Debug.Log($"{player is not null}");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<Dog> { }

    #endregion
    }
}