using UnityEngine;

public class UroUroController : MonoBehaviour
{
    public float moveSpeed = 2.0f;  // 移動速度
    public float moveTime = 2.0f;   // 移動時間
    public float idleTime = 2.0f;   // 停止時間

    private Animator animator;
    private Rigidbody2D rb;
    private bool isMoving = false;
    private float moveDirection = 1.0f;  // 移動方向（初期値は+X方向）

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // 最初に移動を開始
        StartMoving();
    }

    private void Update()
    {
        if (isMoving)
        {
            // 移動中の処理
            rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);

            // 移動中のY回転設定
            if (moveDirection > 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void StartMoving()
    {
        // ランダムに移動方向を決定（+X方向か-X方向か）
        moveDirection = Random.Range(0, 2) == 0 ? 1.0f : -1.0f;

        isMoving = true;
        animator.SetTrigger("Move");
        Invoke("StopMoving", moveTime);
    }

    private void StopMoving()
    {
        isMoving = false;
        rb.velocity = Vector2.zero;
        animator.SetTrigger("Idle");
        Invoke("StartMoving", idleTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突した場合、進行方向を逆にする
        moveDirection *= -1;
    }
}