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

#endregion

#region Public Methods

    public override void InstallBindings()
    {
        Application.targetFrameRate = 60;
        Container.Bind<Transform>().WithId("MainPlayer").FromComponentInNewPrefab(setting.characterPrefab).AsSingle();
        ExampleInstaller.Install(Container);
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