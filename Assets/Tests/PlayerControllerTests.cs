#region

using NSubstitute;
using NUnit.Framework;
using Script;
using Zenject;

#endregion

namespace Tests
{
    public class PlayerControllerTests : ZenjectUnitTestFixture
    {
    #region Private Variables

        private IInputSystem      inputSystem;
        private ICharacterService service;
        private PlayerController  playerController;

    #endregion

    #region Test Methods

        [Test]
        [TestCase(-1 , Description = "輸入值為往左移動")]
        [TestCase(1 ,  Description = "輸入值為往右移動")]
        public void Should_Call_Walk_When_Tick(int exceptHorizontalValue)
        {
            // arrange // given
            inputSystem.GetHorizontalValue().Returns(exceptHorizontalValue);
            // act // when
            playerController.Tick();
            // assert // then
            service.Received(1).Walk(exceptHorizontalValue);
        }

        [Test]
        public void Should_Did_Not_Receive_Walk_When_Tick()
        {
            // arrange // given
            inputSystem.GetHorizontalValue().Returns(0);
            // act // when
            playerController.Tick();
            // assert // then
            service.DidNotReceiveWithAnyArgs().Walk(0);
        }

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();

            Container.Bind<IInputSystem>().FromSubstitute().AsSingle();
            Container.Bind<ICharacterService>().FromSubstitute().AsSingle();
            Container.Bind<PlayerController>().AsSingle();

            inputSystem      = Container.Resolve<IInputSystem>();
            service          = Container.Resolve<ICharacterService>();
            playerController = Container.Resolve<PlayerController>();
        }

    #endregion
    }
}