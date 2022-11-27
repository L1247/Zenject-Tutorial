using System.Collections;
using NUnit.Framework;
using PureCsharp.Core;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class LoadSceneTests : SceneTestFixture
{
    [UnityTest]
    public IEnumerator LoadSceneTestsWithEnumeratorPasses()
    {
        StaticContext.Container.BindInstance(999f).WithId("MoveSpeed");
        yield return LoadScene("ExampleScene");
        var character = SceneContainer.Resolve<ICharacter>();
        // Assert.AreEqual(CharacterState.Idle , character.State);
        Assert.AreEqual(999f ,                 character.MoveSpeed);
        // character.HorizontalMove(1);
    }
}