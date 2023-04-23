#region

using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class FactoryExampleInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<Player>().AsSingle();
            Container.BindInterfacesTo<GameController>().AsSingle();
            Container.Bind<RandomValue>().AsTransient();
            Container.Bind<DifficultyManager>().AsSingle();

            Container.BindFactory<IEnemy , EnemyFactory>().FromFactory<CustomEnemyFactory>();
            Container.BindFactory<Dog , Dog.Factory>().FromComponentInNewPrefabResource("Dog");
            Container.BindFactory<Demon , Demon.Factory>().FromComponentInNewPrefabResource("Demon");

            // FactoryCustomInterface
            // Container.BindFactoryCustomInterface<Dog , Dog.Factory , IEnemyFactory>().FromComponentInNewPrefabResource("Dog");
        }

    #endregion
    }
}