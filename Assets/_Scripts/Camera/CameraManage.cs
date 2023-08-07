using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManage : MonoBehaviour
{
    public CinemachineVirtualCamera cameraObj;
    public Vector3 cameraInitialPositition;
    public static CameraManage Instance { get; private set; }
    public float timerShake;
    private CinemachineBasicMultiChannelPerlin _cbmcp;
    private float stratingIntensity;
    private float TimeShakeTotal;
    private void Start() {
        _cbmcp = cameraObj.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
    }
    private void Awake()
    {
         Instance = this;
         cameraObj = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (timerShake >= 0)
        {
            timerShake -= Time.deltaTime;
            if (timerShake <= 0f)
            {
                _cbmcp = cameraObj.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                _cbmcp.m_AmplitudeGain = 0f;
                Mathf.Lerp(stratingIntensity, 0f, timerShake / TimeShakeTotal);
            }
           
        }
    }

    public void SetActiveObjCameraOn()
    {
        cameraObj.enabled = true;
    }
    
    public void SetActiveObjCameraOff()
    {
        cameraObj.enabled = false;
    }

    public void ShakeCamera(float intensity, float time )
    {
          _cbmcp = cameraObj.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = intensity;
        stratingIntensity = intensity;
        TimeShakeTotal = time;
        timerShake = time;
       



    }
    public void StopShake()
    {
        /*if(timerShake > 0)
        {
            timerShake -= Time.deltaTime;
                _cbmcp = cameraObj.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                _cbmcp.m_AmplitudeGain = 0f;
                Mathf.Lerp(stratingIntensity, 0f, timerShake / TimeShakeTotal);
        }*/
    }
}
