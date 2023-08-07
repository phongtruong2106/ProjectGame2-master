using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private bool isOpenBarrier;
    public int countEnemyCurrent = 10;

    private CameraManage cameraManage;
    public float timerBarishake =0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isOpenBarrier = false;
    }
    private void Awake()
    {
        cameraManage = FindObjectOfType<CameraManage>();
    }

    private void Update()
    {
        if (!isOpenBarrier)        
            CheckCountEnemy();
    }
    private void CheckCountEnemy()
    {
        if(DeathEnemy.deathCount >= countEnemyCurrent)
        {
            
            isOpenBarrier = true;
            
            if (isOpenBarrier)
            {
                anim.SetBool("Open", true);
                CameraManage.Instance.ShakeCamera(1f, 0.7f);
            }
         
        }

    }
    
}
