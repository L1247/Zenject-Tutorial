#region

using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public class MonsterInstaller : Installer<MonsterInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<State1>().AsSingle();
            Container.Bind<State2>().AsSingle();
            Container.Bind<StateMachine1>().AsSingle();
            Container.Bind<StateMachine2>().AsSingle();
            Container.Bind<StateMachineProvider>().AsSingle();
        }

    #endregion
    }
}