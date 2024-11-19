using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    InputActionReference moveActionReference;

    // Start is called before the first execution of Update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = moveActionReference.action.ReadValue<Vector2>();
        rb.linearVelocity = moveDir * moveSpeed;
    }
}
