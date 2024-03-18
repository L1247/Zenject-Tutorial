#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer4.Scripts
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