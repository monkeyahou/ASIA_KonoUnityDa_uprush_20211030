using UnityEngine;

public class EnimiesIndigenous : MonoBehaviour
{
    [Header("角色資訊")]
    public int lives = 20;
    public int attack = 1;
    public float moveRange = 10;

    #region 欄位
    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("移動速度")]
    public float speed = 1.5f;
    [Header("目標圖層")]
    public LayerMask layerTarget;
    #endregion

}
