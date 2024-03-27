#region

using Zenject;

#endregion

namespace Game.Subcontainer5.Scripts
{
    public class GameInstaller_Subcontainer5 : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            GameUIInstaller.Install(Container);
        }

    #endregion
    }
}