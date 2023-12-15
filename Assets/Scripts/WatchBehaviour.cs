using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchBehaviour : MonoBehaviour
{
    [SerializeField] public bool isTimeRunning;
    [SerializeField] public float limitTimeInMinutes;

    public float timeMultiplier = 10;

    [SerializeField] private Text hours;
    [SerializeField] private Text minutes;
    [SerializeField] private Text dots;

    public float timePassed;
    public float realTime;

    [SerializeField] public int initialMinutes;
    [SerializeField] public int initialHours;

    private int lastSecond;
    private int lastMinute;
    private int hoursAcumulated;

    private bool dotsAuxiliar;
    // Start is called before the first frame update
    void Start()
    {
        hours.text = initialHours.ToString();
        minutes.text = initialMinutes.ToString();
        timePassed = 0;
        hoursAcumulated = 0;
        lastMinute = initialMinutes;

        timePassed = initialMinutes*60 + initialHours*3600;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime * timeMultiplier;
        realTime += Time.deltaTime * timeMultiplier;

        if (lastSecond != SecondsPassed())
        {
            render();   
        }

        lastSecond = SecondsPassed();
        lastMinute = MinutesPassed();
    }

    public int MinutesPassed()
    {
        return (int)(timePassed / 60);
    }

    public int SecondsPassed()
    {
        return (int)(timePassed);
    }

    public int HoursPassed()
    {
        return (int)(timePassed / 3600);
    }

    public void render()
    {
        int temp = 0, res = 0;
        
        dots.text = dotsAuxiliar?":" : "";
        dotsAuxiliar = !dotsAuxiliar;

        minutes.text = (MinutesPassed() % 60).ToString("D2");
        hours.text = (HoursPassed() % 24).ToString("D2");
    }
}
