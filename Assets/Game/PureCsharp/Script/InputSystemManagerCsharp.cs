#region

using UnityEngine;

#endregion

namespace PureCsharp.Core
{
    public interface IInputSystem
    {
    #region Public Methods

        /// <summary>
        /// </summary>
        /// <returns>-1 , 0 , 1</returns>
        int GetHorizontalValue();

        bool IsDashKeyDown();

    #endregion
    }

    public class InputSystemManagerCsharp : IInputSystem
    {
    #region Public Methods

        public int GetHorizontalValue()
        {
            // -1 , 0 , 1
            return (int)Input.GetAxisRaw("Horizontal");
        }

        public bool IsDashKeyDown()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

    #endregion
    }
}