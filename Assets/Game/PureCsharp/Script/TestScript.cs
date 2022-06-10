#region

using UnityEngine;

#endregion

namespace PureCsharp.Core
{
    public class TestScript : MonoBehaviour
    {
    #region Private Variables

        private TimeSystem               timeSystem;
        private InputSystemManagerCsharp inputSystem;

    #endregion

    #region Unity events

        private void Awake()
        {
            timeSystem  = new TimeSystem();
            inputSystem = new InputSystemManagerCsharp();
        }

        private void Update()
        {
            // Debug.Log($"{timeSystem.GetDeltaTime()}");
            Debug.Log($"{inputSystem.GetHorizontalValue()}");
        }

    #endregion
    }
}