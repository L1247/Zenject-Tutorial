#region

using Zenject;

#endregion

namespace Game.Subcontainer2.Scripts
{
    public class Test_Mono_Installer : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Runner>().AsSingle();
            Greeter_Main_Installer.Install(Container);
        }

    #endregion
    }
}