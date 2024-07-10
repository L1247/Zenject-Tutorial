#region

using Zenject;

#endregion

namespace Game.SubContainer_With_Interface.Scripts
{
    public class SubContainer_With_Interface_Installer : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameUI>()
                     .FromSubContainerResolve()
                     .ByNewPrefabResourceMethod(nameof(GameUI) , Install)
                     .AsSingle();
        }

    #endregion

    #region Private Methods

        private void Install(DiContainer container)
        {
            container.BindInterfacesTo<GameUI>().AsSingle();
        }

    #endregion
    }
}