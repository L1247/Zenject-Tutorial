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
            Container.BindFactory<State1 , State1.Factory>();
            Container.BindFactory<State2 , State2.Factory>();
            Container.BindFactory<StateMachine1 , StateMachine1.Factory>();
            Container.BindFactory<StateMachine2 , StateMachine2.Factory>();
            Container.BindFactory<int , IStateMachineFactory , StateMachineFactory>().FromFactory<CustomStateMachineFactory>();
        }

    #endregion
    }

    public class CustomStateMachineFactory : IFactory<int , IStateMachineFactory>
    {
    #region Private Variables

        private readonly StateMachine1.Factory stateMachine1Factory;
        private readonly StateMachine2.Factory stateMachine2Factory;

    #endregion

    #region Constructor

        public CustomStateMachineFactory(StateMachine1.Factory stateMachine1Factory , StateMachine2.Factory stateMachine2Factory)
        {
            this.stateMachine2Factory = stateMachine2Factory;
            this.stateMachine1Factory = stateMachine1Factory;
        }

    #endregion

    #region Public Methods

        public IStateMachineFactory Create(int monsterType)
        {
            return monsterType == 1 ? stateMachine1Factory.Create() : stateMachine2Factory.Create();
        }

    #endregion
    }
}