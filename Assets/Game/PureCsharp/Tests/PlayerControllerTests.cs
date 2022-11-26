#region

using NSubstitute;
using NUnit.Framework;
using PureCsharp.Core;
using Zenject;

#endregion

public class PlayerControllerTests : ZenjectUnitTestFixture
{
#region Private Variables

    private IInputSystem      inputSystem;
    private ICharacterService service;
    private PlayerController  playerController;

#endregion

#region Test Methods

    [Test]
    [TestCase(-1 , Description = "輸入值為-1")]
    [TestCase(1 ,  Description = "輸入值為1")]
    [TestCase(0 ,  Description = "輸入值為0")]
    public void Should_Call_Walk_When_Tick(int exceptHorizontalValue)
    {
        // arrange // given
        GivenHorizontalValue(exceptHorizontalValue);
        // act // when
        TickCharacter();
        // assert // then
        Should_Walk(exceptHorizontalValue);
    }

    [Test]
    public void Should_Receive_Dash_When_Tick()
    {
        // arrange // given
        GivenDashKeyDown(true);
        // act // when
        TickCharacter();
        // assert // then
        ShouldDash();
    }

    [Test]
    public void Should_Did_Not_Receive_Dash_When_Tick()
    {
        // arrange // given
        GivenDashKeyDown(false);
        // act // when
        TickCharacter();
        // assert // then
        DidNotDash();
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

#region Private Methods

    private void DidNotDash()
    {
        service.DidNotReceiveWithAnyArgs().Dash();
    }

    private void GivenDashKeyDown(bool keyDown)
    {
        inputSystem.IsDashKeyDown().Returns(keyDown);
    }

    private void GivenHorizontalValue(int exceptHorizontalValue)
    {
        inputSystem.GetHorizontalValue().Returns(exceptHorizontalValue);
    }

    private void Should_Walk(int exceptHorizontalValue)
    {
        service.Received(1).Walk(exceptHorizontalValue);
    }

    private void ShouldDash()
    {
        service.Received(1).Dash();
    }

    private void TickCharacter()
    {
        playerController.Tick();
    }

#endregion
}