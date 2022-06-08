using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance = null;

    public int GetHorizontalValue()
    {
        return (int)Input.GetAxisRaw("Horizontal");
    }

    public static InputManager Instance => instance;
    public        int          Score = 5;

    public void AddScore()
    {
        Score += 10;
    }

    private void Start() { }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}