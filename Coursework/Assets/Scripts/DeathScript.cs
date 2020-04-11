using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script controls two key operations: Player death and respawning.
 * When Player 'dies' the Player game object gets deactivated, at the same time DeathCam is
 * turned on which is a camera looking at nothing but with an overlay
 * which displays a message. After 3 seconds Player respawns, this is
 * controlled by respawncountdown and respawn. Respawn makes Player
 * active again, moves Player to the start position on its charging pad
 * and moves Enemy to its starting position. It also turns off deathcam and 
 * restores player health to 100 */

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
