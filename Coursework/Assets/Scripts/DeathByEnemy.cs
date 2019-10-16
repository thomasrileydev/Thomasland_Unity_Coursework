using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByEnemy : MonoBehaviour {
    public HealthScript healthscript;
public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Enemy"))
        {
            healthscript.Health = healthscript.Health -1;
        }
    }
/*public IEnumerator DamageTimer()
    {
        healthscript.Health = healthscript.Health - 25;
        Debug.Log(healthscript.Health);
        yield return new WaitForSeconds(2);
        Debug.Log("waited");
       
        StopCoroutine("DamageTimer");

    }*/

}
