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

            // act // when
            characterControllerCSharp.HorizontalMove(horizontal);

            // assert // then
            Should_X_Equal(expectedX);
        }

        [Test]
        public void Walk()
        {
            // act
            var horizontalValue = 1;
            characterControllerCSharp.Walk(horizontalValue);
            // assert
            Should_X_Equal(GetXByHorizontal(horizontalValue));
            ShouldStateEqual(CharacterState.Walk);
        }

        [Test]
        public void Given_Walk_State_Did_Not_Walk_When_Walk()
        {
            // given
            // Walk state
            var horizontalValue = 1;
            characterControllerCSharp.Walk(horizontalValue);
            ShouldStateEqual(CharacterState.Walk);

            // act
            characterControllerCSharp.Walk(0);
            Should_X_Equal(GetXByHorizontal(horizontalValue));
            ShouldStateEqual(CharacterState.Idle);
        }

        [Test]
        public void DoDash()
        {
            // act
            Dash();
            TickCharacter();
            // assert
            Should_Dash(25);
        }

        [Test]
        public void DoubleDash()
        {
            // act
            Dash();
            Dash();
            TickCharacter();
            TickCharacter();
            // assert
            Should_Dash(50);
        }

        [Test]
        public void Init()
        {
            ShouldStateEqual(CharacterState.Idle);
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
            GivenDeltaTime(1);
        }

    #endregion

    #region Private Methods

        private void Dash()
        {
            characterControllerCSharp.Dash(1);
            TickCharacter();
        }

        private float GetXByHorizontal(int horizontalValue)
        {
            return horizontalValue * characterControllerCSharp.moveSpeed;
        }

        private void GivenDeltaTime(int deltaTime)
        {
            timeSystem.GetDeltaTime().Returns(deltaTime);
        }

        private void Should_Dash(int expectedX)
        {
            Should_X_Equal(expectedX);
            ShouldStateEqual(CharacterState.Idle);
        }

        private void Should_X_Equal(float expectedX)
        {
            var position = mainCharacter.position;
            Assert.AreEqual(expectedX , position.x , $"position is not equal");
        }

        private void ShouldStateEqual(CharacterState exceptState)
        {
            Assert.AreEqual(exceptState , characterControllerCSharp.State ,
                            "State is not equal");
        }

        private void TickCharacter()
        {
            for (var i = 0 ; i < characterControllerCSharp.defaultDashFrame ; i++)
                characterControllerCSharp.Tick();
        }

    #endregion
    }
}