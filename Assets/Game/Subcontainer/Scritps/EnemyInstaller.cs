#region

using Zenject;

#endregion

namespace Game.Subcontainer.Scritps
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ValueProvider>().AsCached();
            Container.Bind<EnemyFacade>().AsSingle();
        }

    #endregion
    }
}