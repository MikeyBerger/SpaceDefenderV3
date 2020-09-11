using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text TimeText;
    private float StartTime;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float T = Time.time - StartTime;

        string Minutes = ((int)T / 60).ToString();
        string Seconds = (T % 60).ToString();

        TimeText.text = Minutes + " : " + Seconds; 
    }
}
