#region

using NSubstitute;
using NUnit.Framework;
using PureCsharp.Core;
using UnityEngine;
using Zenject;
using CharacterController = PureCsharp.Core.CharacterController;

#endregion

namespace PureCsharp.Tests
{
    public class CharacterControllerTests : ZenjectUnitTestFixture
    {
    #region Private Variables

        private readonly string              transformId = "MainPlayer";
        private          CharacterController characterController;
        private          ITimeSystem         timeSystem;
        private          Transform           mainCharacter;

    #endregion

    #region Test Methods

        [Test]
        [TestCase(-1 , Description = "往左移動")]
        [TestCase(0 ,  Description = "停止移動")]
        [TestCase(1 ,  Description = "往右移動")]
        public void Should_Succeed_When_HorizontalMove(int value)
        {
            // act // when
            HorizontalMove(value);
            // assert // then
            Should_Pos_X_Equal(value);
        }

        [Test]
        public void Should_Succeed_When_Walk()
        {
            // act
            Walk(1);
            // assert
            Should_Pos_X_Equal(1);
            Should_State_Equal(CharacterState.Walk);
        }

        [Test]
        public void Given_Walk_State_Did_Not_Walk_When_Walk()
        {
            // given
            // Should_Succeed_When_Walk state
            Walk(1);
            Should_State_Equal(CharacterState.Walk);

            // act
            characterController.Walk(0);
            Should_Pos_X_Equal(1);
            Should_State_Equal(CharacterState.Idle);
        }

        [Test]
        public void Should_Succeed_When_Dash()
        {
            // act
            Dash();
            TickCharacter();
            // assert
            Should_Dash(1);
        }

        [Test]
        public void DoubleDash()
        {
            // act
            var times = 2;
            DashByCount(times);
            // assert
            Should_Dash(times);
        }

        [Test]
        public void Init()
        {
            Should_State_Equal(CharacterState.Idle);
        }

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();

            Container.Bind<Transform>().WithId(transformId).FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<ITimeSystem>().FromSubstitute().AsSingle();
            Container.Bind<CharacterController>().AsSingle();

            characterController = Container.Resolve<CharacterController>();
            timeSystem          = Container.Resolve<ITimeSystem>();
            mainCharacter       = Container.ResolveId<Transform>(transformId);
            GivenDeltaTime(1);
        }

    #endregion

    #region Private Methods

        private void Dash()
        {
            characterController.Dash(1);
            TickCharacter();
        }

        private void DashByCount(int times)
        {
            for (var i = 0 ; i < times ; i++)
            {
                Dash();
                TickCharacter();
            }
        }

        private float GetXByHorizontal(int horizontalValue)
        {
            return horizontalValue * characterController.moveSpeed;
        }

        private void GivenDeltaTime(int deltaTime)
        {
            timeSystem.GetDeltaTime().Returns(deltaTime);
        }

        private void HorizontalMove(int horizontal)
        {
            characterController.HorizontalMove(horizontal);
        }

        private void Should_Dash(int dashCount)
        {
            var x = characterController.defaultDashFrame * dashCount;
            Should_Pos_X_Equal(x);
            Should_State_Equal(CharacterState.Idle);
        }

        private void Should_Pos_X_Equal(int horizontalValue)
        {
            var exceptX  = GetXByHorizontal(horizontalValue);
            var position = mainCharacter.position;
            Assert.AreEqual(exceptX , position.x , "position is not equal");
        }

        private void Should_State_Equal(CharacterState exceptState)
        {
            Assert.AreEqual(exceptState , characterController.State ,
                            "State is not equal");
        }

        private void TickCharacter()
        {
            for (var i = 0 ; i < characterController.defaultDashFrame ; i++)
                characterController.Tick();
        }

        private void Walk(int value)
        {
            characterController.Walk(value);
        }

    #endregion
    }
}