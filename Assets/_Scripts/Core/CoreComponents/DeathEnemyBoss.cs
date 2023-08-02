using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemyBoss : CoreComponent
{
    public static int deathCount = 0;
    public bool isdead = false;

    [SerializeField]
    private GameObject bossBattel;
    [SerializeField]
    private GameObject[] deathParticles;

    private ParticleManage ParticleManager => particleManage ? particleManage : core.GetCoreComponent(ref particleManage);
    private ParticleManage particleManage;

    private StatsEnemy Stats => stats ? stats : core.GetCoreComponent(ref stats);
    private StatsEnemy stats;

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
        isdead = true;
        bossBattel.GetComponent<BossBattel>().animatorDie();
        
    }

    private void ChangePhase()
    {
        if(isdead)
        {
            bossBattel.GetComponent<BossBattel>().animator.SetBool("Move", true);
            bossBattel.GetComponent<BossBattel>().animator.SetLayerWeight(1, 1f);
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
