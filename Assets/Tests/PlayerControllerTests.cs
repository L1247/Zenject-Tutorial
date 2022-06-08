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

        private IInputSystem     inputSystem;
        private ICharacter       character;
        private PlayerController playerController;

    #endregion

    #region Test Methods

        [Test]
        public void Tick()
        {
            // arrange // given
            var exceptHorizontalValue = 99;
            inputSystem.GetHorizontalValue().Returns(exceptHorizontalValue);
            // act // when
            playerController.Tick();
            // assert // then
            character.Received(1).HorizontalMove(exceptHorizontalValue);
        }

    #endregion

    #region Public Methods

        public override void Setup()
        {
            base.Setup();

            Container.Bind<IInputSystem>().FromSubstitute().AsSingle();
            Container.Bind<ICharacter>().FromSubstitute().AsSingle();
            Container.Bind<PlayerController>().AsSingle();

            inputSystem      = Container.Resolve<IInputSystem>();
            character        = Container.Resolve<ICharacter>();
            playerController = Container.Resolve<PlayerController>();
        }

    #endregion
    }
}