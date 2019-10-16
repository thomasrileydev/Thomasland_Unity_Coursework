using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {


    public Transform sun;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
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
        if (currentTimeOfDay >= 0.75)
        {
            PlayerLight.SetActive (true);   
            
        }
        if (currentTimeOfDay >= 0.25 && currentTimeOfDay <= 0.74)
        {
            PlayerLight.SetActive (false);
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

    }
}
