#region

using NSubstitute;
using NUnit.Framework;
using Script;
using UnityEngine;
using Zenject;

#endregion

namespace Tests
{
    public class CharacterControllerTests : ZenjectUnitTestFixture
    {
    #region Private Variables

        private string                     transformId = "MainPlayer";
        private CharacterController_CSharp characterControllerCSharp;
        private ITimeSystem                timeSystem;
        private Transform                  mainCharacter;

    #endregion

    #region Test Methods

        [Test]
        [TestCase(-1 , -5f , Description = "往左移動")]
        [TestCase(0 ,  0 ,   Description = "停止移動")]
        [TestCase(1 ,  5f ,  Description = "往右移動")]
        public void HorizontalMove(int horizontal , float expectedX)
        {
            // arrange // given
            GivenDeltaTime(1);

            // act // when
            characterControllerCSharp.HorizontalMove(horizontal);

            // assert // then
            Should_X_Equal(expectedX);
        }

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();

            Container.Bind<Transform>().WithId(transformId).FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<ITimeSystem>().FromSubstitute().AsSingle();
            Container.Bind<CharacterController_CSharp>().AsSingle();

            characterControllerCSharp = Container.Resolve<CharacterController_CSharp>();
            timeSystem                = Container.Resolve<ITimeSystem>();
            mainCharacter             = Container.ResolveId<Transform>(transformId);
        }

    #endregion

    #region Private Methods

        private void GivenDeltaTime(int deltaTime)
        {
            timeSystem.GetDeltaTime().Returns(deltaTime);
        }

        private void Should_X_Equal(float expectedX)
        {
            var position = mainCharacter.position;
            Assert.AreEqual(expectedX , position.x , $"position is not equal");
        }

    #endregion
    }
}