using UnityEngine;
using UnityEngine.UI;          // 引用 介面 API
using UnityEngine.Events;      // 引用 事件 API


/// <summary>
/// 受傷系統
/// </summary>
public class HurtSystem : MonoBehaviour
{
    [Header("血條")]
    public Image imgHPBar;
    [Header("血量")]
    public float hp = 100;
    [Header("動畫參數")]
    public string parameterDead = "觸發死亡";
    [Header("死亡事件")]
    public UnityEvent onDead;

    private float hpMax;
    private Animator ani;

    // 喚醒事件 : 在 Start 之前執行一次
    private void Awake()
    {
        ani = GetComponent<Animator>();
        hpMax = hp;
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收到的傷害</param>
    public void Hurt(float damage)
    {
        hp -= damage;
        imgHPBar.fillAmount = hp / hpMax;
        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        ani.SetTrigger(parameterDead);
        onDead.Invoke();
    }

}

