#region

using System;
using PureCsharp.Core;
using UnityEngine;
using Zenject;
using CharacterController = PureCsharp.Core.CharacterController;

#endregion

public class ExampleMonoInstaller : MonoInstaller
{
#region Private Variables

    [Inject]
    private Setting setting;

#endregion

#region Public Methods

    public override void InstallBindings()
    {
        Container.Bind<Transform>().WithId("MainPlayer").FromComponentInNewPrefab(setting.characterPrefab).AsSingle();
        Container.Bind(typeof(ICharacter) , typeof(ITickable)).To<CharacterController>().AsSingle();
        Container.Bind<ICharacterService>().To<CharacterService>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
        Container.Bind<IInputSystem>().To<InputSystemManager>().AsSingle();
        Container.Bind<ITimeSystem>().To<TimeSystem>().AsSingle();
    }

#endregion

#region Nested Types

    [Serializable]
    public class Setting
    {
    #region Public Variables

        public GameObject characterPrefab;

    #endregion
    }

#endregion
}