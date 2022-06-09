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
            var right = Random.Range(-99 , 99);
            characterService.Walk(right);
            character.Received(1).Walk(right);
        }

        [Test]
        public void Dash()
        {
            characterService.Dash();
            character.Received(1).Dash(characterService.dashValue);
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