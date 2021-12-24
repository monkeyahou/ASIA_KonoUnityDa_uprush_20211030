using UnityEngine;

public class EnimiesIndigenous : MonoBehaviour
{
    [Header("�����T")]
    public int lives = 20;
    public int attack = 1;
    public float moveRange = 10;

    #region ���
    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("���ʳt��")]
    public float speed = 1.5f;
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;
    [Header("�ʵe�Ѽ�")]
    public string parameterWalk = "�����}��";
    [Header("���V�ؼЪ���")]
    public Transform target;

    private float angle = 0;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion

    #region �ƥ�
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        // ���w�ϥܪ��C��
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        // ø�s�ߤ���(���ߡA�ؤo)
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize);

    }

    private void Update()
    {
        CheckTargetInArea();
    }

    #endregion


    #region ��k
    /// <summary>
    /// �ˬd�ؼЬO�_�b�ϰ줺
    /// </summary>
    private void CheckTargetInArea()
    {
        // 2D ���z.�л\����(���ߡA�ؤo�A����)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit) Move();
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Move()
    {
        // �T���B��l�y�k : ���L�� ? ���L�� �� true : ���L�� �� false ;
        // �p�G �ؼЪ� x �p�� �ĤH�� x �N�N��b���� ���� 0
        // �p�G �ؼЪ� x �j�� �ĤH�� x �N�N��b�k�� ���� 180

        if (target.position.x > transform.position.x)
        {
            // �k�� angle = 180
        }

        else if (target.position.x > transform.position.x)

        {
            // ���� angle = 0
        }

        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rig.velocity = transform.TransformDirection(new Vector2(-speed, rig.velocity.y));
        ani.SetBool(parameterWalk, true);

        // �Z�� = �T���V�q.�Z��(A�I�AB�I)
        float distance = Vector3.Distance(target.position, transform.position);
        print("�P�ؼЪ��Z�� : " + distance);
    }

    #endregion

}
