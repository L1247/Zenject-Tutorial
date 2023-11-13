#region

using Zenject;

#endregion

namespace Game.BindWithoutOptional.Scripts
{
    public class BindWithoutOptional_Scene_Installer : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TestInterfaceImpl2>().AsSingle();
            BindWithoutOptional_Installer.Install(Container);
        }

    #endregion
    }
}