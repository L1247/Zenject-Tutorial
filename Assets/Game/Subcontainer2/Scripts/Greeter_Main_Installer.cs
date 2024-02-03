#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer2.Scripts
{
    public class Greeter_Main_Installer : Installer<Greeter_Main_Installer>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<Greeter>().FromSubContainerResolve().ByInstaller<Greeter_Installer>().WithKernel().AsSingle().NonLazy();
            // Container.BindFactory<Greeter , Greeter.Factory>()
            // .FromSubContainerResolve()
            // .ByInstaller<Greeter_Installer>()
            // .AsSingle()
            // .NonLazy();
        }

        private void InstallFooFacade(DiContainer subContainer)
        {
            subContainer.Bind<Greeter>().AsSingle();
            subContainer.Bind<ITickable>().To<Bar>().AsSingle();
        }

    #endregion
    }

    internal class Bar:ITickable
    {
        public void Tick()
        {
            Debug.Log($"Tick");
        }
    }
}