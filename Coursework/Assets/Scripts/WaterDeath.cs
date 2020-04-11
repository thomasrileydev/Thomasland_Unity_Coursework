using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This scripts causes Player to lose Health when under water. WaterDeath is a collider
 * inside the oasis in the Desert biome. When Player enters WaterDeath it starts the
 * Coroutine WaterKill and Player loses health at a steady rate until Player gets out.
 * This script doesn't kill Player, that happens in HealthScript if Health falls to zero.
 */

public class WaterDeath : MonoBehaviour {
    public HealthScript HealthScript; //The location of "Health" variable
    private bool WaterExit = true; //WaterExit shows if Player is in the water or not

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterDeath"))
        {
            WaterExit = false; //Player is in the water
            StartCoroutine(WaterKill());
        }
    }
    public IEnumerator WaterKill() //If Player in water, Health is reduced
    {
        HealthScript.Health = HealthScript.Health - 1;
        yield return new WaitForSeconds(2);
        if (WaterExit == false) 
        {
            StartCoroutine(WaterKill());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WaterDeath"))
        {
            StopCoroutine("WaterKill");
            WaterExit = true; //Player is out of the water
        }
    }
}

        
