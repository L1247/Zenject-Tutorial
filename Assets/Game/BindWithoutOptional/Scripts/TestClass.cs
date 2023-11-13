#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.BindWithoutOptional.Scripts
{
    public class TestClass : IInitializable
    {
    #region Private Variables

        [Inject]
        private TestInterface testInterface;

    #endregion

    #region Public Methods

        public void Initialize()
        {
            Debug.Log($"TestInterface Exist: {testInterface != null}");
            Debug.Log($"type: {testInterface}");
        }

    #endregion
    }
}