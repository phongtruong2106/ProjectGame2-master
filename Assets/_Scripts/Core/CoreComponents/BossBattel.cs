using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattel : CoreComponent
{
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
      ChangePhase();
    }

    private void ChangePhase()
    {
        if(DeathEnemy.isDead == true)
        {

          /*  string nameLayer = animator.GetLayerName()
            core.transform.parent.gameObject.SetActive(true);*/
        }
    }
}
