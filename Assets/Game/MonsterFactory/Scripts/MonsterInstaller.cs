#region

using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class MonsterInstaller : MonoInstaller
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
        }

    #endregion
    }
}