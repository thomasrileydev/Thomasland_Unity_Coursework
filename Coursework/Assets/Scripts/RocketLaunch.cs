using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RocketLaunch : MonoBehaviour {

    public GameObject Player;
    public GameObject Enemy;
    public GameObject HUDOverlay;
    public GameObject Rocket;

    public Text CountdownClock;

    public int CountdownValue = 10;

    public ParticleSystem RocketThrust;
    public ParticleSystem PreLaunchEffect;

    public GameObject LaunchCamera;
    public GameObject OnboardCamera;

    public AudioSource RocketNoise;
    public AudioCull AudioCull;

    public void  CountdownInitialize()
    {
        AudioCull.GrasslandAudio.Stop();
        LaunchCamera.SetActive(true);
        Player.SetActive(false);
        Enemy.SetActive(false);
        HUDOverlay.SetActive(false);
        StartCoroutine(Countdown());
    }
       // for (int Increment = 0; Increment < 9; Increment++)
       public IEnumerator Countdown()
        {
        CountdownValue--;
        CountdownClock.text = CountdownValue.ToString();
        yield return new WaitForSeconds(1);
        if (CountdownValue == 6)
        {
            RocketNoise.Play();
        }
        if (CountdownValue > 0)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            CountdownClock.text = "";
            RocketThrust.Play();
            PreLaunchEffect.Stop();
            ConstantForce Thrust = Rocket.GetComponent<ConstantForce>();
            Thrust.enabled=true;
            yield return new WaitForSeconds(15);
            OnboardCamera.SetActive(true);
            LaunchCamera.SetActive(false);
            yield return new WaitForSeconds(20);
            CountdownClock.text = "Well done, you escaped! Now restarting...";
            yield return new WaitForSeconds(5);
            //OnboardCamera.SetActive(false);
            //Rocket.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Final Game", LoadSceneMode.Single);



        }
    }
    

}
