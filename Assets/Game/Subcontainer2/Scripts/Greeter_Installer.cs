#region

using Zenject;

#endregion

namespace Game.Subcontainer2.Scripts
{
    public class Greeter_Installer : Installer<Greeter_Installer>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            InstallGreeter(Container);
        }

    #endregion

    #region Private Methods

        private void InstallGreeter(DiContainer subContainer)
        {
            subContainer.Bind<Greeter>().AsSingle();

            subContainer.BindInterfacesTo<GoodbyeHandler>().AsSingle();
            subContainer.BindInterfacesTo<HelloHandler>().AsSingle();
        }

    #endregion
    }
}