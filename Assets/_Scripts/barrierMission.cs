using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierMission : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", false);
    }

    public void SetBarrierMissionOn()
    {
        anim.SetBool("Open", true);
    }

    public void SetBarrierMissionOff()
    {
        anim.SetBool("Close", true);
    }
}
