using System;
using UnityEngine;

public class DeathEnemy : CoreComponent
{
        [SerializeField ] 
        private GameObject[] deathParticles;
        public static int deathCount = 0;

        private ParticleManage ParticleManager =>particleManage ? particleManage : core.GetCoreComponent(ref particleManage);
        private ParticleManage particleManage;
        public static bool isDead;

        private StatsEnemy Stats => stats ? stats : core.GetCoreComponent(ref stats);
        private StatsEnemy stats;

        private void Start()
        {
            isDead = false;
        }
        public void Die()
         {
                foreach (var particle in deathParticles)
                {
                    ParticleManager.StartParticles(particle);
                }
                core.transform.parent.gameObject.SetActive(false);
                deathCount++;
                Debug.Log("Death Enemy Count: " + DeathEnemy.deathCount);
                isDead = true;
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
