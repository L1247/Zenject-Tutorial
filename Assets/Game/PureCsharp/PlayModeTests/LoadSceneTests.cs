using System.Collections;
using NUnit.Framework;
using PureCsharp.Core;
using UnityEngine.TestTools;
using Zenject;

public class LoadSceneTests: SceneTestFixture
{
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator LoadSceneTestsWithEnumeratorPasses()
    {
        yield return LoadScene("ExampleScene");
        var character = SceneContainer.Resolve<ICharacter>();
        Assert.AreEqual(CharacterState.Idle , character.State);
    }
}