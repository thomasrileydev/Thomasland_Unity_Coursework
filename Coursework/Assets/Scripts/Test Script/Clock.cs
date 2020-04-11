/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    //float hoursToDegrees = 360f / 12f;
    //float minutesToDegrees = 360f / 60f;
    DayNight controller;

    void Awake()
    {
        controller = GameObject.Find("GameController").GetComponent<DayNight>();
    }

    void Update()
    {
        float currentHour = 24 * controller.currentTimeOfDay;
        float currentMinute = 60 * (currentHour - Mathf.Floor(currentHour));

        //hourHand.localRotation = Quaternion.Euler(currentHour * hoursToDegrees, 0, 0);
        //minuteHand.localRotation = Quaternion.Euler(currentMinute * minutesToDegrees, 0, 0);
    }

}*/
