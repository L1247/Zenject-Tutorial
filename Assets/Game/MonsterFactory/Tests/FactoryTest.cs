#region

using Game.MonsterFactory.Scripts;
using NUnit.Framework;
using Zenject;

#endregion

namespace Game.MonsterFactory.Tests
{
    public class FactoryTest : ZenjectUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void TestFactory()
        {
            Container.Bind<RandomValue>().AsTransient();
            Container.BindFactory<int , Demon , Demon.Factory>().FromComponentInNewPrefabResource("Demon");

            var factory = Container.Resolve<Demon.Factory>();
            factory.Create(2);
        }

    #endregion
    }
}