using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;  // Tốc độ di chuyển của camera
    public float jumpForce; // Lực nhảy của người chơi
    private bool isJumping = false; // Kiểm tra xem người chơi có đang nhảy hay không

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
        float horizontalInput = Input.GetAxis("Horizontal");  // Lấy giá trị đầu vào ngang từ các phím mũi tên hoặc A/D
        float verticalInput = Input.GetAxis("Vertical");  // Lấy giá trị đầu vào dọc từ các phím mũi tên hoặc W/S

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);  // Tạo vector hướng di chuyển

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);  // Di chuyển camera

        // Bạn có thể thay đổi transform.Translate thành transform.position += moveDirection * moveSpeed * Time.deltaTime
        // nếu bạn muốn viết theo cách khác.
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
