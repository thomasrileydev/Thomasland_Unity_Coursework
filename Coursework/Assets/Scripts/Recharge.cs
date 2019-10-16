using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharge : MonoBehaviour {

    public HealthScript healthscript;
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
