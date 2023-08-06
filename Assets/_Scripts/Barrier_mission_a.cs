using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_mission_a : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private DeathEnemyBoss deathEnemyBoss;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        setBarrierClose();
    }
    public void setBarrierClose()
    {
        if(DeathEnemyBoss.isDeadPhaseC)
        {
            anim.SetBool("Close", true);
        }
        
    }
}
