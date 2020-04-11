using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*This defines the class LookCamera which controls the vertical rotation of player camera
    It only affects the camera and doesn't actually rotate the transform of the player (so player doesn't fall over or fly)
    Inputs from the right analogue stick and the up and down mouse movement move the player camera up and down
    within limits in the if statements */

public class LookCamera : MonoBehaviour { 
    public float Speed; //Camera rotation speed
    public Transform Cam; //Camera transform
    //public int minAngle=-50; //No longer used
    //public int maxAngle=35;
    private void FixedUpdate() //Updates vertical rotation each physics update if there is an input
    {

        float LookVertical = Input.GetAxis("Right Stick Vertical"); //Right analogue stick
        float MouseLookVertical = Input.GetAxis("Mouse Y"); //Mouse movement

        if (LookVertical > 0) //If there is an upward movement from the right stick
        {
            if (transform.localRotation.x <= 0.31f) //Applies rotation if within limit
            {
                //LookVertical = Mathf.Clamp(LookVertical, minAngle, maxAngle); //No longer used
                transform.Rotate(new Vector3(LookVertical, 0, 0) * Time.deltaTime * Speed, Space.Self);
            }
        }
        if (LookVertical < 0) //If there is a downward movement from the right stick
        {
            if (transform.localRotation.x >= -0.4f) //Applies rotation if within limit
            {
                //LookVertical = Mathf.Clamp(LookVertical, minAngle, maxAngle); //No longer used
                transform.Rotate(new Vector3(LookVertical, 0, 0) * Time.deltaTime * Speed, Space.Self);
            }
        }
        if (MouseLookVertical > 0) //If there is an upward movement from the mouse or pointer device
        {
            if (transform.localRotation.x <= 0.31f) //Applies rotation if within limit
            {
                //MouseLookVertical = MouseLookVertical * Time.deltaTime * Speed; //No longer used
                //MouseLookVertical = Mathf.Clamp(MouseLookVertical, minAngle, maxAngle); 
                //transform.Rotate(new Vector3(MouseLookVertical, 0, 0), Space.Self);
                transform.Rotate(new Vector3(MouseLookVertical, 0, 0) * Time.deltaTime * Speed, Space.Self); 
            }
        }
        if (MouseLookVertical < 0) //If there is an downward movement from the mouse or pointer device
        {
            if (transform.localRotation.x >= -0.4f) //Applies rotation if within limit
            {
                // MouseLookVertical = MouseLookVertical * Time.deltaTime * Speed; //No longer used
                //MouseLookVertical = Mathf.Clamp(MouseLookVertical, minAngle, maxAngle); 
                //transform.Rotate(new Vector3(MouseLookVertical, 0, 0), Space.Self);
                transform.Rotate(new Vector3(MouseLookVertical, 0, 0) * Time.deltaTime * Speed, Space.Self); 
            }
        }


    }
}