#region

using System;
using UnityEngine;

#endregion

namespace Game.Subcontainer4.Scripts
{
    public class GoodbyeHandler : IDisposable
    {
    #region Public Methods

        public void Dispose()
        {
            Debug.Log("Goodbye World!");
        }

    #endregion
    }
}