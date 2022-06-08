#region

using UnityEngine;

#endregion

namespace Script
{
    public interface IInputSystem
    {
    #region Public Methods

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