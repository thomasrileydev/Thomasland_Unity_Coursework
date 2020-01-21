using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour {
    public HealthScript HealthScript;
    private bool WaterExit = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterDeath"))
        {
            WaterExit = false;
            StartCoroutine(WaterKill());
        }
    }
    public IEnumerator WaterKill()
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
            WaterExit = true;
        }
    }
}

        
