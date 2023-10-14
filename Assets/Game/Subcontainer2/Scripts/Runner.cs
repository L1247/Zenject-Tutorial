#region

using System;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer2.Scripts
{
    public class Runner : IInitializable , IDisposable
    {
    #region Private Variables

        private readonly Greeter.Factory _greeterFactory;

        private Greeter greeter;

    #endregion

    #region Constructor

        public Runner(Greeter.Factory greeterFactory)
        {
            _greeterFactory = greeterFactory;
        }

    #endregion

    #region Public Methods

        public void Dispose()
        {
            greeter.Dispose();
        }

        public void Initialize()
        {
            Debug.Log("Initialize");
            greeter = _greeterFactory.Create();
            greeter.Initialize();
            Debug.Log($"{greeter}");
        }

    #endregion
    }
}