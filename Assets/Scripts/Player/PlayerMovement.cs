using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody2D _rigidbody;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        _rigidbody.linearVelocity = moveInput * _moveSpeed;
    }
}
