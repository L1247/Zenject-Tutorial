#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer3.Scripts
{
    public class ShipInstaller : Installer<ShipInstaller>
    {
    #region Private Variables

        private readonly float _speed;

    #endregion

    #region Constructor

        public ShipInstaller(
                [InjectOptional] float speed)
        {
            _speed = speed;
        }

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ShipFacade>().AsSingle();
            Container.Bind<Transform>().FromComponentOnRoot();
            Container.BindInterfacesTo<ShipInputHandler>().AsSingle();
            Container.BindInstance(_speed).WhenInjectedInto<ShipInputHandler>();
            Container.Bind<ShipHealthHandler>().FromNewComponentOnRoot().AsSingle();
        }

    #endregion
    }
}