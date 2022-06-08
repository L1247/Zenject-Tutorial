using System;
using UnityEngine;

namespace Script
{
    public class TestScript : MonoBehaviour
    {
        private TimeSystem               timeSystem;
        private InputSystemManagerCsharp inputSystem;

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
    }
}