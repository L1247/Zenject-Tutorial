#region

using UnityEngine;
using Zenject;

#endregion

namespace PureCsharp.Core
{
    public class ExampleInstaller : Installer<ExampleInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind(typeof(ICharacter) , typeof(ITickable)).To<CharacterController>().AsSingle();
            Container.Bind<ICharacterService>().To<CharacterService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
            Container.Bind<IInputSystem>().To<InputSystemManager>().AsSingle();
            Container.Bind<ITimeSystem>().To<TimeSystem>().AsSingle();
        }

    #endregion
    }
}