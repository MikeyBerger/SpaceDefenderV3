using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class TimerData
{
    public float CurrentTime;
    public float TopTime;

    public TimerData(TimerScript TS)
    {
        CurrentTime = TS.StartTime;
    }


}
