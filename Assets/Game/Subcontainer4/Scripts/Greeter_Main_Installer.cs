#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer4.Scripts
{
    public class Greeter_Main_Installer : Installer<Greeter_Main_Installer>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Runner>().AsSingle();

            Container.BindFactory<Greeter , Greeter.Factory>()
                     .FromSubContainerResolve()
                     .ByMethod(InstallFooFacade)
                     .AsSingle();
        }

    #endregion

    #region Private Methods

        private void InstallFooFacade(DiContainer subContainer)
        {
            subContainer.Bind<Greeter>().AsSingle();
            subContainer.BindInterfacesTo<Bar>().AsSingle();
            AAA_Installer.Install(subContainer);
        }

    #endregion
    }

    internal class Bar : ITickable , IInitializable
    {
    #region Public Methods

        public void Initialize()
        {
            Debug.Log("bar Initialize");
        }

        public void Tick()
        {
            Debug.Log("bar Tick");
        }

    #endregion
    }
}