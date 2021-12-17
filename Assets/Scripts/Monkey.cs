using UnityEngine;

public class Monkey : MonoBehaviour
{
    // Start is called before the first frame update
    #region 公開
    public int lives = 3;
    public float height = 0;
    public bool dead = false;
    public bool unlock = true;

    public float moveSpeed;
    [Range(300, 1000)]
    public float jump = 300;

    [Header("檢查地板尺寸與位移")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyJump = KeyCode.Space;
    public LayerMask canJumpLayer;
    #endregion

    #region 私人
    [SerializeField]
    private bool isGrounded;
    
    private Rigidbody2D mrig;
    private Animator mAnim;
    #endregion

    #region 事件
    private void Start()
    {
        mrig = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();

    }
    private void Update()

    {
        Flip();
        CheckGround();
        Jump();

    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);

    }
#endregion

    #region 方法
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        // 如果 h 小於 0 左 : 角度 Y 0
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //如果 h 值 大於 0 右:角度 Y 0
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    private void CheckGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
        transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        isGrounded = hit;
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //print("玩家左右按鍵值:" + h);
        mrig.velocity = new Vector2(h * moveSpeed, mrig.velocity.y);

        if (h != 0)
        {
            mAnim.SetBool("走路開關", true);
        }
        else
        {
            mAnim.SetBool("走路開關", false);
        }

    }
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(keyJump))
        {
            mrig.AddForce(new Vector2(0, jump));
        }

        if (!isGrounded)
        {
            mAnim.SetBool("跳躍開關", true);
        }
        else
        {
            mAnim.SetBool("跳躍開關", false);
        }
    }
    #endregion
}


