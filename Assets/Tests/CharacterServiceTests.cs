#region

using NSubstitute;
using NUnit.Framework;
using Script;
using UnityEngine;
using Zenject;

#endregion

namespace Tests
{
    public class CharacterServiceTests : ZenjectUnitTestFixture
    {
    #region Private Variables

        private CharacterService characterService;
        private ICharacter       character;

    #endregion

    #region Test Methods

        [Test]
        public void Walk()
        {
            character.State.Returns(CharacterState.Idle);
            var right = Random.Range(-99 , 99);
            characterService.Walk(right);
            character.Received(1).Walk(right);
        }

        [Test]
        public void Did_Not_Walk()
        {
            character.State.Returns(CharacterState.Dash);
            characterService.Walk(99);
            character.DidNotReceiveWithAnyArgs().Walk(0);
        }


        [Test]
        public void Dash()
        {
            character.State.Returns(CharacterState.Walk);
            characterService.Dash();
            character.Received(1).Dash(characterService.dashValue);
        }

        [Test]
        [TestCase(CharacterState.Idle)]
        [TestCase(CharacterState.Dash)]
        public void Did_Not_Dash(CharacterState characterState)
        {
            character.State.Returns(characterState);
            characterService.Dash();
            character.DidNotReceiveWithAnyArgs().Dash(0);
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
    }
}