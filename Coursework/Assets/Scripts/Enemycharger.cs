using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
