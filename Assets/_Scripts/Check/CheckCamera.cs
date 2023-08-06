using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraManage;
    [SerializeField]
    private LayerMask layeMask;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(layeMask == (layeMask | (1 << other.gameObject.layer)))
        {
            cameraManage.GetComponent<CameraManage>().SetActiveObjCameraOff();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(layeMask == (layeMask | (1 << other.gameObject.layer)))
        {
            cameraManage.GetComponent<CameraManage>().SetActiveObjCameraOn();
        }
    }
}
