#region

using Zenject;

#endregion

namespace Game.Subcontainer5.Scripts
{
    public class SubContainerInstaller : Installer<SubContainerInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<SubcontainerClass>()
                     .FromSubContainerResolve()
                     .ByNewPrefabResourceMethod("SubcontainerClass" , InstallerMethod)
                     .UnderTransformGroup("GameUI")
                     .AsSingle()
                     .NonLazy();
        }

    #endregion

    #region Private Methods

        private void InstallerMethod(DiContainer obj)
        {
            obj.Bind<SubcontainerClass>().AsSingle();
        }

    #endregion
    }
}