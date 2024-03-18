#region

using Zenject;

#endregion

namespace Game.Subcontainer4.Scripts
{
    public class Test_Mono_Installer : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Greeter_Main_Installer.Install(Container);
        }

    #endregion
    }
}