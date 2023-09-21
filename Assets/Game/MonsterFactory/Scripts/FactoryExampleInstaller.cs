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

            // Container.BindFactory<IEnemy , EnemyFactory>().FromFactory<CustomEnemyFactory>();
            // use customEnemyFactory for ConCreate factory type , instead EnemyFactory
            Container.BindFactoryCustomInterface<IEnemy , CustomEnemyFactory , IEnemyFactory>().FromFactory<CustomEnemyFactory>();
            Container.BindFactory<Dog , Dog.Factory>().FromComponentInNewPrefabResource("Dog");
            Container.BindFactory<int,Demon , Demon.Factory>().FromComponentInNewPrefabResource("Demon");
        }

    #endregion
    }
}