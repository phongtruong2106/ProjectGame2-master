using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : MonoBehaviour
{
    [SerializeField]
    private barrierMission barrier;

    [SerializeField]
    private LayerMask layerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            barrier.GetComponent<barrierMission>().SetBarrierMissionOn();
            CameraManage.Instance.ShakeCamera(1f, 0.7f);
            
        }
    }
}
