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
        public void Construct(Player player) { }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<Dog>
                // public class Factory : PlaceholderFactory<Dog> , IDogFactory
        { }

    #endregion
    }
}