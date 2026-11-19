
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 3f;
    public float gravity = -25f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // WASD 이동
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (move.magnitude > 1f)
            move.Normalize();

        controller.Move(move * moveSpeed * Time.deltaTime);

        // 스페이스바를 누르면 언제든 점프
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 중력 적용
        velocity.y += gravity * Time.deltaTime;

        // 위아래 이동
        controller.Move(velocity * Time.deltaTime);
    }
}
