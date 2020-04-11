using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script runs when Player contacts one of the spanners collectables. It starts
 * InitializeRegen which increases Player health back up to full and it also deactivates
 * the collectable. */

public class WrenchScript : MonoBehaviour {

    public ControllerScript ControllerScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ControllerScript.InitializeRegen();
            gameObject.SetActive(false);
        }
    }

}
