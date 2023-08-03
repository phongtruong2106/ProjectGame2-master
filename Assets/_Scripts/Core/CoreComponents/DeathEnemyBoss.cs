using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemyBoss : CoreComponent
{
    public static int deathCount = 0;
    public bool isdead = false;
    public bool isDeadPhase = false;
    private bool activateLiveAnimator = false;
    public float healthPhase = 200f;
    public float meleeAttack = 100f;
    public float rangedAttack = 100f;

    [SerializeField]
    private GameObject bossBattel;
    [SerializeField]
    private GameObject[] deathParticles;

    private ParticleManage ParticleManager => particleManage ? particleManage : core.GetCoreComponent(ref particleManage);
    private ParticleManage particleManage;

    private StatsEnemy Stats => stats ? stats : core.GetCoreComponent(ref stats);
    private StatsEnemy stats;
    [SerializeField]
    private float waitTime = 0;
    [SerializeField]
    private float waitTimeCurrent = 3f;
    private Coroutine waitCoroutine;
    
    private AttackDetail attackDetail;
    

    private void Update()
    {
        ChangePhase();
    }

    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }
        waitTime = 0f;
        isdead = true;
        bossBattel.GetComponent<BossBattel>().animatorDie();

        // Nếu đã có một coroutine đang chạy, hãy dừng nó trước khi bắt đầu một coroutine mới.
        if (waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
        }
        checkPhaseDie();
    }

    public void ChangePhase()
    {
        if(isdead)
        {
            if (!activateLiveAnimator) // Nếu chưa kích hoạt trạng thái "Live" của animator
            {
                waitTime += Time.deltaTime; // Tăng biến đếm thời gian
                Debug.Log(waitTime);
                // Kiểm tra nếu đã đạt đến thời gian mong muốn (5 giây)
                if (waitTime >= 5f)
                {
                    activateLiveAnimator = true; // Đánh dấu rằng đã đủ thời gian để kích hoạt trạng thái "Live"
                    bossBattel.GetComponent<BossBattel>().animatorCloseDie();
                }
            }

            if (activateLiveAnimator)
            {

                bossBattel.GetComponent<BossBattel>().animatorLive();
                Stats.ResetHealth(healthPhase);
                attackDetail.attackPhaseProtitel(rangedAttack);
                // Thực hiện các hành động khi đạt đủ thời gian để kích hoạt trạng thái "Live"
                bossBattel.GetComponent<BossBattel>().animator.SetLayerWeight(1, 1f);
                isdead = false;
                isDeadPhase = true;
                activateLiveAnimator = false; // Reset cờ để sử dụng cho lần sau
            }
        }
    }
    public void checkPhaseDie()
    {
        if(isDeadPhase)
        {
            Destroy(core.transform.parent.gameObject);
            Debug.Log("Boss die");
        }
    }
    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }
    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}
