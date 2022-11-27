#region

using UnityEngine;
using Zenject;

#endregion

namespace PureCsharp.Core
{
    [CreateAssetMenu(fileName = "ExampleScriptableObject" , menuName = "Example/ExampleScriptableObject" , order = 0)]
    public class ExampleScriptableObject : ScriptableObjectInstaller
    {
    #region Private Variables

        [SerializeField]
        private ExampleMonoInstaller.Setting exampleMonoInstaller;

        [SerializeField]
        private float moveSpeed;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            // Debug.Log($"{Container.ResolveId<float>()}");
            Container.BindInstance(exampleMonoInstaller);
            Container.BindInstance(moveSpeed).WithId("MoveSpeed").IfNotBound();
        }

    #endregion
    }
}