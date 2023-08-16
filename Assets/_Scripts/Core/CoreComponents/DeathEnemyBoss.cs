using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemyBoss : CoreComponent
{

    public static DeathEnemyBoss Instance;
    public static int deathCount = 0;
    public bool isdead = false;
    public bool isCheckPhase = false;
    public bool isdeathPhase = false;
    public static bool isDeadPhaseC = false;
    private bool activateLiveAnimator = false;
    public float healthPhase = 200f;
    public float meleeAttack = 100f;
    public float rangedAttack = 100f;
    public GameObject cutSceneTimelineobj;

    [SerializeField]
    private GameObject bossBattel;
    [SerializeField]
    private GameObject[] deathParticles;
    [SerializeField]
    private float waitTime = 0;
    [SerializeField]
    private float waitTimeCurrent = 3f;

    private ParticleManage ParticleManager => particleManage ? particleManage : core.GetCoreComponent(ref particleManage);
    private ParticleManage particleManage;
    private StatsEnemy Stats => stats ? stats : core.GetCoreComponent(ref stats);
    private StatsEnemy stats;
    private Coroutine waitCoroutine;
    public BossBattel BossBattel;
    public EnemyBoss1 EnemyBoss1;
    public LootBag lootBag;

    private AttackDetail attackDetail;


    private void Start()
    {
        cutSceneTimelineobj.SetActive(false);
    }
    private void Update()
    {
        liveCutScenes();
        /*ChangePhase();*/

    }

    public void Die()
    {
        if (!StatsEnemy.isHealth)
        {
            bossBattel.GetComponent<BossBattel>().animatorDie();
            isdead = true;
        }

        CheckPhaseDie();
    }

    public void liveCutScenes()
    {
        if (isdead)
        {

            Invoke(nameof(CutScenes), 2f);
            isCheckPhase = true;
            if (isCheckPhase)
            {
                bossBattel.GetComponent<BossBattel>().animatorCloseDie();
                bossBattel.GetComponent<BossBattel>().animator.SetLayerWeight(1, 1f);
                stats.ResetHealth(healthPhase);
                attackDetail.attackPhaseProtitel(rangedAttack);
                isdead = false;
                isdeathPhase = true;
            }
        }
    }

    private void CutScenes()
    {
        cutSceneTimelineobj.SetActive(true);
    }

    public void CheckPhaseDie()
    {
        if (isdeathPhase)
        {
            foreach (var particle in deathParticles)
            {
                ParticleManager.StartParticles(particle);
            }

            lootBag.GetComponent<LootBag>().GetItemsDropp();
            Destroy(core.transform.parent.gameObject);
            Debug.Log("Boss die");
            isDeadPhaseC = true;
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