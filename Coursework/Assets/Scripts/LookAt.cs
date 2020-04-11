using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This is used by LaunchCamera to point it at Rocket when Rocket is activated. It also 
 * tracks the Rocket when it launches. Since this script is modular it could be used
 * to track other objects. This script was provided in standard assets. */

public class LookAt : MonoBehaviour
{
    public Transform target;
   

    void Update()
    {
        
        transform.LookAt(target); //Rotates camera every frame so it looks at the Rocket
    }
}
