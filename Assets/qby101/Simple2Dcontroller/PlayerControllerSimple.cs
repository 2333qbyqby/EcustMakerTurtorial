using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//全部写在update里面，不推荐
public class PlayerControllerSimple : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("速度")]
    [SerializeField]
    private float speed = 5.0f;
    [Header("跳跃高度")]
    private float jumpHeight = 5.0f;
    [Header("跳跃重力大小")]
    public float jumpGravityScale = 1.0f;
    public float fallGravityScale = 2.5f;
    public float airGravityScale = 1.5f;
    [Header("大跳长按时间")]
    public float jumpTime = 0.2f;
    private float jumpTimer = 0;
    [Header("滞空界限")]
    public float jumpLimit = 1f;
    private Rigidbody2D rb;
    [Header("地面检测")]
    public Transform groundCheck;
    public LayerMask layerMask;


    private bool isJump = false;
    private bool isGround = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.gravityScale = jumpGravityScale;
    }
    private void Update()
    {
        #region 处理移动
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            float dir = Input.GetAxis("Horizontal");
            float d = dir > 0 ? 1 : -1;
            rb.velocity = new Vector2(speed * d, rb.velocity.y);

        }
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) <= 0.01)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        #endregion


        #region 地面检测
        if (Physics2D.OverlapBox(groundCheck.position, groundCheck.localScale, 0, layerMask) != null)
        {
            isGround = true;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            Debug.Log(isGround);
        }
        else
        {
            isGround = false;
        }
        #endregion
        //根据速度方向来调整重力大小
        if (!isJump)
        {
            rb.gravityScale = jumpGravityScale;
        }

        # region 处理跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                float jumpForce = Mathf.Sqrt(jumpHeight * -2f * Physics2D.gravity.y * rb.gravityScale) * rb.mass;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJump = true;
                jumpTimer = 0;
            }
        }
        //计时
        if (isJump)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer < jumpTime && Input.GetKeyUp(KeyCode.Space))
            {
                rb.gravityScale = fallGravityScale;
            }
            if (rb.velocity.y < 0)
            {
                isJump = false;
            }

            if( Mathf.Abs(rb.velocity.y)<=jumpLimit)
            {
                rb.gravityScale = airGravityScale;
            }
        }
        #endregion
    }
    private void FixedUpdate()
    {
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, groundCheck.localScale);
    }

}
