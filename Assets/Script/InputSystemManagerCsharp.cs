using UnityEngine;
using Zenject;

namespace Script
{
    public interface IInputSystem
    {
    #region Public Methods

        int GetHorizontalValue();

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

    #endregion
    }
}