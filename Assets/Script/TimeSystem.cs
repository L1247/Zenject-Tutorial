using UnityEngine;

namespace Script
{
    public interface ITimeSystem
    {
    #region Public Methods

        float GetDeltaTime();

    #endregion
    }

    public class TimeSystem : ITimeSystem
    {
    #region Public Methods

        public float GetDeltaTime()
        {
            var deltaTime = Time.deltaTime;
            return deltaTime;
        }

    #endregion
    }
}