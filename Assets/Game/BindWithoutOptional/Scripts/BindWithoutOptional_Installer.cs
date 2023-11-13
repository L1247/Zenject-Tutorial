#region

using Zenject;

#endregion

namespace Game.BindWithoutOptional.Scripts
{
    public class BindWithoutOptional_Installer : Installer<BindWithoutOptional_Installer>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TestInterfaceImpl>().AsSingle().IfNotBound();
            Container.BindInterfacesTo<TestClass>().AsSingle();
        }

    #endregion
    }
}