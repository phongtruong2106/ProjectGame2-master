using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CutScenesManage : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator camAnim;

    [SerializeField]
    private PlayerData playerData;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerData.movementVelocity = 0f;
            isCutsceneOn = true;
            camAnim.SetBool("CutScenes_1", true);
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    private void StopCutscene()
    {
        playerData.movementVelocity = 4f;
        isCutsceneOn= false;
        camAnim.SetBool("CutScenes_1", false);
        Destroy(gameObject);
    }
}
