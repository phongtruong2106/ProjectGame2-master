using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattel : MonoBehaviour
{
    
    public Animator animator;
    public Animation anim;

    private void Start()
    {
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
    }

    public void animatorDie()
    {
        animator.SetBool("Death", true);
    }
}
