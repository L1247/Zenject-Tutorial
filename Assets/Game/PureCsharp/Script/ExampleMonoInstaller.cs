#region

using System;
using PureCsharp.Core;
using UnityEngine;
using Zenject;

#endregion

public class ExampleMonoInstaller : MonoInstaller
{
#region Private Variables

    [Inject]
    private Setting setting;

    [Inject]
    private IAMDontDestroy iamDontDestroy;

    [Inject]
    private ZenjectSceneLoader sceneLoader;

#endregion

#region Public Methods

    public override void InstallBindings()
    {
        iamDontDestroy.Log();
        Container.Bind<Transform>().WithId("MainPlayer").FromComponentInNewPrefab(setting.characterPrefab).AsSingle();
        ExampleInstaller.Install(Container);
        // sceneLoader.LoadScene("MenuScene");
    }

#endregion

#region Nested Types

    [Serializable]
    public class Setting
    {
    #region Public Variables

        public GameObject characterPrefab;

    #endregion
    }

#endregion
}