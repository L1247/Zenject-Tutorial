#region

using UnityEngine;

#endregion

namespace PureCsharp.Core
{
    public class TestScript : MonoBehaviour
    {
    #region Private Variables

        private TimeSystem         timeSystem;
        private InputSystemManager inputSystem;

    #endregion

    #region Unity events

        private void Awake()
        {
            timeSystem  = new TimeSystem();
            inputSystem = new InputSystemManager();
        }

        private void Update()
        {
            // Debug.Log($"{timeSystem.GetDeltaTime()}");
            Debug.Log($"{inputSystem.GetHorizontalValue()}");
        }

    #endregion
    }
}