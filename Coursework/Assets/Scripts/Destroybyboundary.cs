using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script destroys a game object if it goes out of the 
 * boundary of the game. It is applied to Player and Boulder 
 * but could be applied to others as it is modular. If Player 
 * goes out of the boundary then PlayerDie is called which kills
 * and respawns Player. Any other game object is turned off, relocated
 * to the position given in the inspector and turned back on again.*/

public class Destroybyboundary : MonoBehaviour {
    public DeathScript DeathScript;
    public Vector3 ObjectStart;
    public void Obliterate() //This disappears the game object - called by the void below
    {
        gameObject.SetActive(false);
        Unobliterate();
    }
    public void Unobliterate() //This reinstates the game object - called by the void below
    {
        transform.position = ObjectStart;
        gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Boundary"))
        {
            //If player meets boundary, player dies and respawns
            //any other game object is turned off and reset
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
