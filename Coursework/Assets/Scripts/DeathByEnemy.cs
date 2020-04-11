using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script controls interaction between Enemy and Player. When Enemy's collider
 * contacts Player's collider the health goes down by 1 and the damage sound plays.
 * This script doesn't directly kill Player when health drops to zero, this is
 * handled by healthscript. */

public class DeathByEnemy : MonoBehaviour {
    public HealthScript healthscript;
    public AudioSource DamageAudio;
public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Enemy"))
        {
            if (DamageAudio.isPlaying == false)
            {
                DamageAudio.Play();
            }
                healthscript.Health = healthscript.Health - 1;
        }
    }   
    //This was my first method which didn't work very well, it isn't that dissimilar to
    //the current method
/*public IEnumerator DamageTimer()
    {
        healthscript.Health = healthscript.Health - 25;
        Debug.Log(healthscript.Health);
        yield return new WaitForSeconds(2);
        Debug.Log("waited");
       
        StopCoroutine("DamageTimer");

    }*/

}
