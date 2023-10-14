#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer2.Scripts
{
    public class HelloHandler : IInitializable
    {
    #region Public Methods

        public void Initialize()
        {
            Debug.Log("Hello world!");
        }

    #endregion
    }
}