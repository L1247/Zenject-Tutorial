#region

using UnityEngine;

#endregion

namespace PureCsharp.Core
{
    public class IAMDontDestroy : MonoBehaviour
    {
    #region Unity events

        private void Awake()
        {
            // Debug.Log("Awake: IAMDontDestroy");
        }

    #endregion

    #region Public Methods

        public void Log()
        {
            Debug.Log("IAMDontDestroy");
        }

    #endregion
    }
}