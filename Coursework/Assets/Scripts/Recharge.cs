using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script is applied to Player, when player is in contact with the charging pad
 * Player's battery is recharged until it reaches a value of 200 which is full or
 * Player leaves the pad. */

public class Recharge : MonoBehaviour {

    public HealthScript healthscript; //The variable 'Battery' is in HealthScript 
    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("PlayerCharge"))
        {

            if (healthscript.Battery < 200)
            {
                healthscript.Battery = healthscript.Battery + 1;
            }
        }
    }
}
