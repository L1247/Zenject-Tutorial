#region

using NSubstitute;
using NUnit.Framework;
using PureCsharp.Core;
using UnityEngine;
using Zenject;

#endregion

public class CharacterServiceTests : ZenjectUnitTestFixture
{
#region Private Variables

    private CharacterService characterService;
    private ICharacter       character;

#endregion

#region Test Methods

    [Test]
    public void DoWalk()
    {
        var right = Random.Range(-99 , 99);
        GivenCharacterState(CharacterState.Idle);
        Walk(right);
        ShouldWalk(right);
    }

    [Test]
    public void Did_Not_Walk()
    {
        GivenCharacterState(CharacterState.Dash);
        Walk(99);
        DidNotWalk();
    }


    [Test]
    public void DoDash()
    {
        GivenCharacterState(CharacterState.Walk);
        Dash();
        Should_Dash();
    }

    [Test]
    [TestCase(CharacterState.Idle)]
    [TestCase(CharacterState.Dash)]
    public void Did_Not_Dash(CharacterState characterState)
    {
        GivenCharacterState(characterState);
        Dash();
        DidNotDash();
    }

#endregion

#region Public Methods

    public override void Setup()
    {
        base.Setup();
        Container.Bind<CharacterService>().AsSingle();
        Container.Bind<ICharacter>().FromSubstitute();
        characterService = Container.Resolve<CharacterService>();
        character        = Container.Resolve<ICharacter>();
    }

#endregion

#region Private Methods

    private void Dash()
    {
        characterService.Dash();
    }

    private void DidNotDash()
    {
        character.DidNotReceiveWithAnyArgs().Dash(0);
    }

    private void DidNotWalk()
    {
        character.DidNotReceiveWithAnyArgs().Walk(0);
    }

    private void GivenCharacterState(CharacterState characterState)
    {
        character.State.Returns(characterState);
    }

    private void Should_Dash()
    {
        character.Received(1).Dash(characterService.dashValue);
    }

    private void ShouldWalk(int right)
    {
        character.Received(1).Walk(right);
    }

    private void Walk(int right)
    {
        characterService.Walk(right);
    }

#endregion
}