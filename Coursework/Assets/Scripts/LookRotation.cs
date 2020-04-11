using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script controls the horizontal rotation of PlayerCamera. It allows a full 360 degrees
 * of rotation at a speed set in the inspector. It uses inputs from the mouse or pointer 
 * and the right stick on the game controller, only using the horizontal component (x axis)
 */

public class LookRotation : MonoBehaviour {
    public float Speed;
    private void FixedUpdate()
    {

        float LookHorizontal = Input.GetAxis("Right Stick Horizontal");
        float MouseLookHorizontal = Input.GetAxis("Mouse X");
      
        if (LookHorizontal != 0)
        {
            transform.Rotate(new Vector3(0, LookHorizontal, 0) * Time.deltaTime * Speed, Space.World);
        }
        if (MouseLookHorizontal != 0)
        {
            transform.Rotate(new Vector3(0, MouseLookHorizontal, 0) * Time.deltaTime * Speed, Space.World);
        }
    
    }
}
       