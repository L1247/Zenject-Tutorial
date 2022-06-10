#region

using UnityEngine;

#endregion

public class InputManager : MonoBehaviour
{
#region Public Variables

    public static InputManager Instance { get; private set; }

    public int Score = 5;

#endregion

#region Unity events

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() { }

#endregion

#region Public Methods

    public void AddScore()
    {
        Score += 10;
    }

    public int GetHorizontalValue()
    {
        return (int)Input.GetAxisRaw("Horizontal");
    }

#endregion
}