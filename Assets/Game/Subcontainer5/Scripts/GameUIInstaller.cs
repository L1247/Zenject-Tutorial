#region

using Zenject;

#endregion

namespace Game.Subcontainer5.Scripts
{
    public class GameUIInstaller : Installer<GameUIInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            SubContainerInstaller.Install(Container);
        }

    #endregion
    }
}