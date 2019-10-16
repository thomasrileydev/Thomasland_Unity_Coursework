using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {
    public GameObject Player;
    public Transform PlayerTransform;
    public Transform EnemyTransform;
    public GameObject DeathCam;
    public HealthScript healthscript;
   
       

    public void PlayerDie () {

            Player.SetActive(false);
            DeathCam.SetActive(true);
            StartCoroutine(RespawnCountdown());
            
        

    }
    IEnumerator RespawnCountdown()
    {
      
        yield return new WaitForSeconds(2);
        Respawn();
        StopCoroutine("RespawnCountdown");       
       // StopAllCoroutines(); // this may need changing if it stops other coroutines that need to continue (was a problem)
    }
    public void Respawn()
    {
        healthscript.Health = 100;
        PlayerTransform.position = new Vector3(0, 53, 0);
        PlayerTransform.rotation = Quaternion.Euler(0, 0, 0);
        EnemyTransform.position = new Vector3(0, 53, 500);
        Player.SetActive(true);
        DeathCam.SetActive(false);
    }
    

}
