using Script;
using UnityEngine;
using Zenject;

public class SampleMonoInstaller : MonoInstaller
{
#region Public Methods

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<CharacterController_CSharp>().AsSingle();
        Container.Bind<IInputSystem>().To<InputSystemManagerCsharp>().AsSingle();
        Container.Bind<ITimeSystem>().To<TimeSystem>().AsSingle();
    }

#endregion
}