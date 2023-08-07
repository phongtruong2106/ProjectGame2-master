using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_mission_a : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private bool isOpenBarrier;
/*    private DeathEnemyBoss deathEnemyBoss;*/

    private void Start()
    {
        anim = GetComponent<Animator>();
        isOpenBarrier = false;
    }

    private void Update()
    {
        if (!isOpenBarrier)
        setBarrierClose();
    }
    public void setBarrierClose()
    {

        if(DeathEnemyBoss.isDeadPhaseC)
        {
            isOpenBarrier = true;
            if(isOpenBarrier)
            {
                anim.SetBool("Close", true);
                CameraManage.Instance.ShakeCamera(1f, 0.7f);
            }
            
        }
        
    }
}
