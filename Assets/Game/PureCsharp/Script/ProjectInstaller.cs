#region

using UnityEngine;
using Zenject;

#endregion

namespace PureCsharp.Core
{
    public class ProjectInstaller : MonoInstaller
    {
    #region Private Variables

        [SerializeField]
        private IAMDontDestroy iamDontDestroyPrefab;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;
            var iamDontDestroy = Container.InstantiatePrefabForComponent<IAMDontDestroy>(iamDontDestroyPrefab);
            Container.Bind<IAMDontDestroy>().FromInstance(iamDontDestroy).AsSingle();
        }

    #endregion
    }
}