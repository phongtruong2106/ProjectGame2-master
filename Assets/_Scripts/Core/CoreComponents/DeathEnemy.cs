using System;
using UnityEngine;
using Photon.Pun;

public class DeathEnemy : CoreComponent
{
    [SerializeField]
    private GameObject[] deathParticles;
    public static int deathCount = 0;

    private ParticleManage ParticleManager => particleManage ? particleManage : core.GetCoreComponent(ref particleManage);
    private ParticleManage particleManage;

    private StatsEnemy Stats => stats ? stats : core.GetCoreComponent(ref stats);
    private StatsEnemy stats;

    [PunRPC]
    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }

        // Hủy enemy trước khi tắt GameObject cha
        Destroy(core.transform.parent.gameObject);

        // Tắt GameObject cha của enemy
        core.transform.parent.gameObject.SetActive(false);

        deathCount++;

        PhotonView photonView = PhotonView.Get(this);

        // Gọi RPC để thông báo enemy đã chết cho các máy chơi khác
        photonView.RPC("EnemyDied", RpcTarget.All);

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