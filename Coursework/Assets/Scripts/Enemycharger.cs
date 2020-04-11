using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script controls what happens to Player when it contacts the 
 * Enemy charging pad. When the colliders are in contact, Player's
 * health is reduced, referencing HealthScript */
public class Enemycharger : MonoBehaviour {

    public HealthScript healthscript;
    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Enemycharger"))
        {
            //Debug.Log(healthscript.Health);         
            
                healthscript.Health = healthscript.Health - 1;
           
        }
    }
}
