#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer2.Scripts
{
    public class Greeter : Kernel
    {
    #region Constructor

        public Greeter()
        {
            Debug.Log("Created Greeter!");
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<Greeter> { }

    #endregion
    }
}