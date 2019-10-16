using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbyboulder : MonoBehaviour {
    public DeathScript DeathScript;
    public Transform boulder;
    public float deathspeed;  


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigid = boulder.GetComponent<Rigidbody>();
        if (other.CompareTag("Player")&&rigid.velocity.y<deathspeed)
        {
            DeathScript.PlayerDie();           
        }
    }


}
