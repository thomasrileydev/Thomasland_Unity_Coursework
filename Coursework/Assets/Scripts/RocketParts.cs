using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketParts : MonoBehaviour {
    private string Box1 = "Box1";
    private string Box2 = "Box2";
    private string Box3 = "Box3";
    private string Box4 = "Box4";

    [HideInInspector] public bool Collected1;
    [HideInInspector] public bool Collected2;
    [HideInInspector] public bool Collected3;
    [HideInInspector] public bool Collected4;
    public RocketLaunch RocketLaunch;

    public GameObject Crate1;
    public GameObject Crate2;
    public GameObject Crate3;
    public GameObject Crate4;
    public GameObject Rocket;
    public GameObject RocketPart1;
    public GameObject RocketPart2;
    public GameObject RocketPart3;

    public Slider RocketProgress;
    //public void Start() { Collected1 = true; Collected2 = true; Collected3 = true; Collected4 = true; Rocket.SetActive(true); }
    public void OnTriggerEnter(Collider other)
    {
       
      if (other.CompareTag(Box1))
        {
            Collected1 = true;
            Crate1.SetActive(false);
            RocketPart1.SetActive(true);
            RocketProgress.value = 1;
        }
        if (Collected1 == true)
        {
            if (other.CompareTag(Box2))
            {
                Collected2 = true;
                Crate2.SetActive(false);
                RocketPart1.SetActive(false);
                RocketPart2.SetActive(true);
                RocketProgress.value = 2;


            }
        }
        if (Collected2 == true)
        {
            if (other.CompareTag(Box3))
            {
                Collected3 = true;
                Crate3.SetActive(false);
                RocketPart2.SetActive(false);
                RocketPart3.SetActive(true);
                RocketProgress.value = 3;

            }
        }
        if (Collected3 == true)
        {
            if (other.CompareTag(Box4))
            {
                Collected4 = true;
                Crate4.SetActive(false);
                RocketPart3.SetActive(false);
                Rocket.SetActive(true);
                RocketProgress.value = 4;

            }
            
         if (Collected4 == true)
            {
                if (other.CompareTag("Rocket"))
                {
                    RocketLaunch.CountdownInitialize();
                }
            }
        }
    }
        
}
