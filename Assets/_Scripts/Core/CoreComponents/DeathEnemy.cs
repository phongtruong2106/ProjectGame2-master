using System;
using UnityEngine;

public class DeathEnemy : CoreComponent
{
    [SerializeField]
    private GameObject[] deathParticles;
    public static int deathCount = 0;

    private ParticleManage ParticleManager => particleManage ? particleManage : core.GetCoreComponent(ref particleManage);
    private ParticleManage particleManage;

    private StatsEnemy Stats => stats ? stats : core.GetCoreComponent(ref stats);
    private StatsEnemy stats;

    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }
        core.transform.parent.gameObject.SetActive(false);
        Destroy(core.transform.parent.gameObject);
        deathCount++;
        Debug.Log("Death Enemy Count: " + DeathEnemy.deathCount);
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