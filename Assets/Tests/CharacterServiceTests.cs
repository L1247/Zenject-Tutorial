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
    #region Test Methods

        [Test]
        public void Walk()
        {
            Container.Bind<CharacterService>().AsSingle();
            Container.Bind<ICharacter>().FromSubstitute();
            var characterService = Container.Resolve<CharacterService>();
            var character        = Container.Resolve<ICharacter>();
            var right            = Random.Range(-99 , 99);
            characterService.Walk(right);

            character.Received(1).Walk(right);
        }

    #endregion
    }
}