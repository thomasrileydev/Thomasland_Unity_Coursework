using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* This script controls day and night in the game, movement of the sun in 
 * the sky and turning on (and off) Player's light according to the time of day.
 * The Sun and Moon are lights, the moon is 180 degrees opposite the Sun which is
 * an abstraction of day and night lighting but it works fine for this application.
 * Game time in Unity ranges from 0 to 1 and in my game the day/night cycle is
 * 12 minutes (although this could be changed in the inspector) so I used a
 * value called currentTimeOfDay to be the time in my game ranging from 0 to 1.
 * You could also change the time multiplier, I decided to leave it set as 1 as
 * I wanted it to look like a natural day and night cycle. */

public class DayNight : MonoBehaviour {


    public Transform sun;
    public float secondsInFullDay = 720f; //For 12 minutes day night cycle
    [Range(0, 1)] //Range of the slider in the inspector
    public float currentTimeOfDay = 0.25f; //Sets time to morning at the start
    public float timeMultiplier = 1f;
    public GameObject PlayerLight;



    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
        if (currentTimeOfDay < 0.25 || currentTimeOfDay >= 0.75)
        {
            PlayerLight.SetActive (true);   //Turns on player light at night
            
        }
        if (currentTimeOfDay >= 0.25 && currentTimeOfDay <= 0.74)
        {
            PlayerLight.SetActive (false); //Turns off player light in the day
        }
    }

    void UpdateSun() //Updates sun's position relative to time of day. 
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

    }
}
