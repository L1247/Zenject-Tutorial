#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.SubContainer_With_Interface.Scripts
{
    public class GameUI : IInitializable
    {
    #region Public Methods

        public void Initialize()
        {
            Debug.Log("Initialize");
        }

    #endregion
    }
}