using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManage : MonoBehaviour
{
    public CinemachineVirtualCamera cameraObj;
    public Vector3 cameraInitialPositition;
    [SerializeField]
    private float ShakeIntensity = 1f;
    private float ShakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;
    private void Start() {
        cameraObj = GetComponent<CinemachineVirtualCamera>();
    }

    public void SetActiveObjCameraOn()
    {
        cameraObj.enabled = true;
    }
    
    public void SetActiveObjCameraOff()
    {
        cameraObj.enabled = false;
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcq = cameraObj.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;
        timer = ShakeTime;
    }

    public void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcq = cameraObj.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }
    
}
