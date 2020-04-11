using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script deals with collecting the parts to build the rocket.
 * It also triggers the launch of the rocket.
 * There are four if statements that deal with building the rocket 
 * as the collectables are acquired, there are three part built stages
 * of the Rocket that are activated by collecting the boxes of Rocket parts,
 * plus the complete Rocket.
 * RocketProgress.value updates the Rocket progress indicator in the HUD */

public class RocketParts : MonoBehaviour {
    private string Box1 = "Box1"; //The 4 collectables' tags
    private string Box2 = "Box2";
    private string Box3 = "Box3";
    private string Box4 = "Box4";

    [HideInInspector] public bool Collected1; //
    [HideInInspector] public bool Collected2;
    [HideInInspector] public bool Collected3;
    [HideInInspector] public bool Collected4;
    public RocketLaunch RocketLaunch;

    public GameObject Crate1; //The 4 collectables
    public GameObject Crate2;
    public GameObject Crate3;
    public GameObject Crate4;
    public GameObject Rocket; //The completed Rocket
    public GameObject RocketPart1; //The 3 part built stages of Rocket
    public GameObject RocketPart2;
    public GameObject RocketPart3;

    public Slider RocketProgress; //The progress bar for Rocket
    //public void Start() { Collected1 = true; Collected2 = true; Collected3 = true; Collected4 = true; Rocket.SetActive(true); }
    //This line was used for testing - it assembled a complete rocket at the start of the game
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
            
         if (Collected4 == true) //If the Rocket is complete and Player contacts it
            {
                if (other.CompareTag("Rocket"))
                {
                    RocketLaunch.CountdownInitialize(); //CountdownInitialize starts
                }
            }
        }
    }
        
}
