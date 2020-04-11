using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This is a generic collectables script I created which, when Player contacts
 * a collectable makes the collectable disappear and instantiate the related object.
 * It is used by MiniMap and Boulder and because it is modular it
 * could be used by new objects that need to be collected to make something else appear.*/

public class CollectablesScript : MonoBehaviour {

    public string Tag="Player";
    public GameObject Collectable;
    public GameObject AddOn;

    void Start()
    {
        AddOn.SetActive(false); //Sets the add-on to false at the start of the game
    }

void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag)) //When a collectable is contacted by player
        {
            Collectable.SetActive (false); //The collectable is turned off
            AddOn.SetActive(true); //and the add-on is turned on

        }
    }
}
