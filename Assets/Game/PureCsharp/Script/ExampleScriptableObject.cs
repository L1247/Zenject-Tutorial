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

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(exampleMonoInstaller);
        }

    #endregion
    }
}