#region

using System.Collections;
using NUnit.Framework;
using PureCsharp.Core;
using UnityEngine.TestTools;
using Zenject;

#endregion

public class BindThroughTheSceneTests : SceneTestFixture
{
#region Public Methods

    [UnityTest]
    public IEnumerator Pass_Argument_For_Character()
    {
        StaticContext.Container.BindInstance(999f).WithId("MoveSpeed");
        yield return LoadScene("ExampleScene");
        var character = SceneContainer.Resolve<ICharacter>();
        Assert.AreEqual(999f , character.MoveSpeed);
    }

#endregion
}