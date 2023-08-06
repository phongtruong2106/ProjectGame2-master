using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private bool isOpenBarrier;
    public int countEnemyCurrent = 10;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isOpenBarrier = false;
    }

    private void Update()
    {
        CheckCountEnemy();
    }
    private void CheckCountEnemy()
    {
        if(DeathEnemy.deathCount >= countEnemyCurrent)
        {
            isOpenBarrier = true;    
        }

        if(isOpenBarrier)
        {
            anim.SetBool("Open", true);
        }
    }
}
