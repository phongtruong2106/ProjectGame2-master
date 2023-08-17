using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeClock : MonoBehaviour
{
    public float secondSpeed;

    public int clockTime;

    public bool night = false;

    public Light2D globallight;
    public Light2D[] Clamdlight;
    public Light2D[] houselight;
    [SerializeField]
    private DataTime dataTime;

    private void Start()
    {
        InvokeRepeating("TimePasses", secondSpeed, secondSpeed);
        InvokeRepeating("DayNightSwitch", 2f, 2f);
    }
    private void FixedUpdate()
    {
        SwitchLigths();
    }
    public void TimePasses()
    {
        dataTime.mm++;
        if(dataTime.mm > 59)
        {
            dataTime.mm = 0;
            dataTime.hh++;
            clockTime++;
            CheckClock();
        }
    }

    private void CheckClock()
    {
        if(dataTime.hh > 23)
        {
            dataTime.hh = 0;
        }
    }

    public void SwitchLigths()
    {
        float tagetInensity;
        if(night)
        {
           tagetInensity = 0.1f;
           globallight.intensity = Mathf.Lerp(globallight.intensity, tagetInensity, Time.deltaTime * 0.2f);
            foreach(Light2D ligth in houselight)
            {
                ligth.intensity = Mathf.Lerp(ligth.intensity, 2.85f, Time.deltaTime * 1f);
            }
            foreach (Light2D ligth in Clamdlight)
            {
                ligth.intensity = Mathf.Lerp(ligth.intensity, 1.09f, Time.deltaTime * 1f);
            }
        }
        else
        {
            tagetInensity = 1.06f;
            globallight.intensity = Mathf.Lerp(globallight.intensity, tagetInensity, Time.deltaTime * 0.2f);
            foreach (Light2D ligth in houselight)
            {
                ligth.intensity = Mathf.Lerp(ligth.intensity, 0f, Time.deltaTime * 1f);
            }
            foreach (Light2D ligth in Clamdlight)
            {
                ligth.intensity = Mathf.Lerp(ligth.intensity, 0f, Time.deltaTime * 1f);
            }
        }
    }

    public void DayNightSwitch()
    {
        if(dataTime.hh < 18 && dataTime.hh > 5)
        {
            night = false;
        }
        else
        {
            night = true;
        }
    }

}
