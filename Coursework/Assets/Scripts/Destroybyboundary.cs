using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroybyboundary : MonoBehaviour {
    public DeathScript DeathScript;
    public Vector3 ObjectStart;
    public void Obliterate()
    {
        gameObject.SetActive(false);
        Unobliterate();
    }
    public void Unobliterate()
    {
        transform.position = ObjectStart;
        gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            if (name == "Player")
            {
                DeathScript.PlayerDie();
            }
            else
            {
                Obliterate();
            }
            

        }
        
    }
}
