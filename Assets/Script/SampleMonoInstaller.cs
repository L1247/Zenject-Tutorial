#region

using Script;
using Zenject;

#endregion

public class SampleMonoInstaller : MonoInstaller
{
#region Public Methods

    public override void InstallBindings()
    {
        Container.Bind<ICharacter>().To<CharacterController_CSharp>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
        Container.Bind<IInputSystem>().To<InputSystemManagerCsharp>().AsSingle();
        Container.Bind<ITimeSystem>().To<TimeSystem>().AsSingle();
    }

#endregion
}