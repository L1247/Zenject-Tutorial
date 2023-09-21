#region

using Game.MonsterFactory.Scripts;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using Zenject;

#endregion

public class GameControllerTests
{
#region Test Methods

    [Test(Description = "Create a enemy when Initialize")]
    public void CreateEnemy()
    {
        var enemyFactory      = Substitute.For<IEnemyFactory>();
        var difficultyManager = new DifficultyManager();
        var gameController    = new GameController(enemyFactory , difficultyManager);
        gameController.Initialize();
        enemyFactory.Received(1).Create();
        Assert.AreEqual(Difficulties.Hard , difficultyManager.Difficulty);
    }

    [Test(Description = "Create a diff enemy when Initialize")]
    public void CreateEnemyForDiffEnemy()
    {
        var diContainer = new DiContainer();
        diContainer.Bind<Player>().AsSingle();
        diContainer.Bind<GameController>().AsSingle();
        diContainer.Bind<RandomValue>().AsTransient();
        diContainer.Bind<DifficultyManager>().AsSingle();
        diContainer.BindFactoryCustomInterface<IEnemy , CustomEnemyFactory , IEnemyFactory>().FromFactory<CustomEnemyFactory>();
        diContainer.BindFactory<Dog , Dog.Factory>().FromComponentInNewPrefabResource("Dog");
        diContainer.BindFactory<int , Demon , Demon.Factory>().FromComponentInNewPrefabResource("Demon");

        var gameController = diContainer.Resolve<GameController>();
        gameController.Initialize();
        Assert.AreEqual(1 , Object.FindObjectsOfType<Demon>().Length);
        gameController.Initialize();
        Assert.AreEqual(1 , Object.FindObjectsOfType<Dog>().Length);
    }

#endregion
}