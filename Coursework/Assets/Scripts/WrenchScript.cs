using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
