using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //adds scene management tools needed to reload scene
using UnityEngine.UI;

/*This handles the Rocket launch procedure. CountdownInitialize is called from RocketParts
 * when Player contacts the completed Rocket. CountdownInitialize then calls Countdown which
 * handles the countdown, launch and reset at the end of the game. */

public class RocketLaunch : MonoBehaviour {

    public GameObject Player;
    public GameObject Enemy;
    public GameObject HUDOverlay;
    public GameObject Rocket;

    public Text CountdownClock;

    [HideInInspector] public int CountdownValue = 10;

    public ParticleSystem RocketThrust;
    public ParticleSystem PreLaunchEffect;

    public GameObject LaunchCamera;
    public GameObject OnboardCamera;

    public AudioSource RocketNoise;
    public AudioCull AudioCull;

    public void  CountdownInitialize() //Handles pre-countdown
    {
        AudioCull.GrasslandAudio.Stop(); //Stops ambient sounds
        LaunchCamera.SetActive(true);
        Player.SetActive(false); //Also turns off the Player's camera 
        Enemy.SetActive(false); //Turns off Enemy
        HUDOverlay.SetActive(false); //Turns off HUD
        StartCoroutine(Countdown()); //Starts Countdown
    }
       // for (int Increment = 0; Increment < 9; Increment++)
       public IEnumerator Countdown() //Controls countdown, rocket launch and restarts game
        {
        CountdownValue--;
        CountdownClock.text = CountdownValue.ToString();
        yield return new WaitForSeconds(1);
        if (CountdownValue == 6)
        {
            RocketNoise.Play(); //Rocket noise audio plays
        }
        if (CountdownValue > 0)
        {
            StartCoroutine(Countdown());
        }
        else //which is when CountdownValue = 0
        {
            CountdownClock.text = ""; //clears the text
            RocketThrust.Play(); //This is the particle system for the engine thrust / flames
            PreLaunchEffect.Stop(); //Stops the mist produced by Rocket before launch
            ConstantForce Thrust = Rocket.GetComponent<ConstantForce>();
            Thrust.enabled=true; //Turns on Rocket thrust
            yield return new WaitForSeconds(15); //after 15 seconds the camera changes from distant to on board
            OnboardCamera.SetActive(true);
            LaunchCamera.SetActive(false);
            yield return new WaitForSeconds(20); //20 seconds viewing the Rocket launch from on board
            CountdownClock.text = "Well done, you escaped! Now restarting..."; //displays completion message
            yield return new WaitForSeconds(5);
            //OnboardCamera.SetActive(false);
            //Rocket.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Final Game", LoadSceneMode.Single); //resets the scene



        }
    }
    

}
