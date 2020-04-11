using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script controls killing the Player if Boulder falls on Player at a fast enough speed.
 * Deathspeed is set in the Unity inspector so that Boulder hitting Player at speed kills
 * Player but Player can still push Boulder around in the world. */

public class Deathbyboulder : MonoBehaviour {
    public DeathScript DeathScript;
    public Transform boulder;
    public float deathspeed;  


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigid = boulder.GetComponent<Rigidbody>();
        if (other.CompareTag("Player")&&rigid.velocity.y<deathspeed)
        {
            DeathScript.PlayerDie(); //This calls the script that kills Player          
        }
    }


}
