#region

using Zenject;

#endregion

namespace Game.Subcontainer2.Scripts
{
    public class Greeter_Main_Installer : Installer<Greeter_Main_Installer>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindFactory<Greeter , Greeter.Factory>()
                     .FromSubContainerResolve()
                     .ByInstaller<Greeter_Installer>()
                     .AsSingle()
                     .NonLazy();
        }

    #endregion
    }
}