#region

using UnityEngine;

#endregion

public class CharacterController : MonoBehaviour
{
#region Private Variables

    private readonly InputManager inputManager = new InputManager();

    [SerializeField]
    private float moveSpeed = 5;

#endregion

#region Unity events

    // Start is called before the first frame update
    private void Start() { }

    // Update is called once per frame
    private void Update()
    {
        var horizontal = InputManager.Instance.GetHorizontalValue();
        if (horizontal == 0)
            return;
        transform.position += Vector3.right * (horizontal * Time.deltaTime) * moveSpeed;
    }

#endregion
}