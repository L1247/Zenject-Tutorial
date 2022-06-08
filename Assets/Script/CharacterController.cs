using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;

    private readonly InputManager inputManager = new InputManager();

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        var horizontal = InputManager.Instance.GetHorizontalValue();
        if (horizontal == 0)
            return;
        transform.position += Vector3.right * (horizontal * Time.deltaTime) * moveSpeed;
    }
}