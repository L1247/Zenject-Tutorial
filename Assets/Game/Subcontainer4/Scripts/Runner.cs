#region

using System;
using Zenject;

#endregion

namespace Game.Subcontainer4.Scripts
{
    public class Runner : IInitializable , IDisposable , ITickable
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
            greeter = _greeterFactory.Create();
            greeter.Initialize();
        }

        public void Tick()
        {
            greeter.Tick();
        }

    #endregion
    }
}