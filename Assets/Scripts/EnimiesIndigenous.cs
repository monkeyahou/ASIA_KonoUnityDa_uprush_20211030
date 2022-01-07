using UnityEngine;

public class EnimiesIndigenous : MonoBehaviour
{
   

    #region 欄位
    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("移動速度")]
    public float speed = 1.5f;
    [Header("目標圖層")]
    public LayerMask layerTarget;
    [Header("動畫參數")]
    public string parameterWalk = "走路開關";
    public string parameterAttack = "觸發攻擊";
    [Header("面向目標物件")]
    public Transform target;
    [Header("攻擊距離"), Range(0, 5)]
    public float attackDistance = 1.3f;
    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float attackCD = 2.8f;
    [Header("檢查攻擊區域大小與位移")]
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackOffset;

    private float angle = 0;
    private Rigidbody2D rig;
    private Animator ani;
    private float timerAttack;

    #endregion

    #region 事件
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        // 指定圖示的顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        // 繪製立方體(中心，尺寸)
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize);

        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize);
    }

    private void Update()
    {
        CheckTargetInArea();
    }

    #endregion


    #region 方法
    /// <summary>
    /// 檢查目標是否在區域內
    /// </summary>
    private void CheckTargetInArea()
    {
        // 2D 物理.覆蓋盒形(中心，尺寸，角度)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit) Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 三元運算子語法 : 布林值 ? 當布林值 為 true : 當布林值 為 false ;
        // 如果 目標的 x 小於 敵人的 x 就代表在左邊 角度 0
        // 如果 目標的 x 大於 敵人的 x 就代表在右邊 角度 180

        if (target.position.x > transform.position.x)
        {
            // 右邊 angle = 180
        }

        else if (target.position.x > transform.position.x)

        {
            // 左邊 angle = 0
        }

        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rig.velocity = transform.TransformDirection(new Vector2(-speed, rig.velocity.y));
        ani.SetBool(parameterWalk, true);

        // 距離 = 三維向量.距離(A點，B點)
        float distance = Vector3.Distance(target.position, transform.position);
        print("與目標的距離 : " + distance);

        if (distance <= attackDistance)       // 如果 距離 小於等於 攻擊距離
        {
            rig.velocity = Vector3.zero;      // 停止
            Attack();
        }

    }

    [Header("攻擊力"), Range(0, 100)]
    public float attack = 50;

    /// <summary>
    /// 攻擊
    /// </summary>

    private void Attack()
    {
        if (timerAttack < attackCD)               // 如果 計時器 小於 冷卻時間
        {
            timerAttack += Time.deltaTime;        // 時間累加 Time.deltaTime 一幀的時間
        }

        else
        {
            ani.SetTrigger(parameterAttack);      // 如果 計時器 大於等於 冷卻時間 就 攻擊
            timerAttack = 0;                      // 計時器 歸零
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3AttackSize, 0, layerTarget);
            hit.GetComponent<HurtSystem>().Hurt(attack);
        }
    }
     
    #endregion

}
