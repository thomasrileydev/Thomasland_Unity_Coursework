using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour {
    public GameObject Player;
    public Transform PlayerTransform;
    public Transform EnemyTransform;
    public GameObject DeathCam;
    public HealthScript healthscript;
    public Text RespawnClock;
    //private int RespawnValue=5;
       

    public void PlayerDie () {

            Player.SetActive(false);
            DeathCam.SetActive(true);
            StartCoroutine(RespawnCountdown());
            
        

    }
    IEnumerator RespawnCountdown()
    {
       // RespawnValue--;  Respawn countdown didn't work. For Else loop hashed out so Respawn still works.
       // RespawnClock.text = RespawnValue.ToString();
        yield return new WaitForSeconds(3);

       // if (RespawnValue > 0)
       // {
         //   StartCoroutine(RespawnCountdown());
        // }
        //else
        //{
            Respawn();
            StopCoroutine("RespawnCountdown");
        //}
               
       // StopAllCoroutines(); // this may need changing if it stops other coroutines that need to continue (was a problem)
    }
    public void Respawn()
    {
        //RespawnValue = 5;
        healthscript.Health = 100;
        PlayerTransform.position = new Vector3(0, 53, 0);
        PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
        EnemyTransform.position = new Vector3(0, 53, 497);
        Player.SetActive(true);
        DeathCam.SetActive(false);
    }
    

}
