using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeClock : MonoBehaviour
{
    public int hh;
    public int mm;

    public int clockTime;

    public bool night = false;
/*
    public Light2D globallight;
    public Light2D houselight;*/


    public void TimePasses()
    {
        mm++;
        if(mm > 59)
        {
            mm = 0;
            hh++;
            clockTime++;
            CheckClock();
            DayNightSwitch();
        }
    }

    private void CheckClock()
    {
        if(clockTime > 23)
        {
            clockTime = 0;
        }
    }

    public void DayNightSwitch()
    {
        if(clockTime < 21 && clockTime > 5)
        {
            night = false;
        }
        else
        {
            night = true;
        }
    }

}
