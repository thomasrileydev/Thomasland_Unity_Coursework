using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour {
    public float Speed;
    public Transform Cam;
    //public int minAngle=-50;
    //public int maxAngle=35;
    private void FixedUpdate()
    {

        float LookVertical = Input.GetAxis("Right Stick Vertical");
        float MouseLookVertical = Input.GetAxis("Mouse Y");

        if (LookVertical > 0)
        {
            if (transform.localRotation.x <= 0.31f)
            {
                //LookVertical = Mathf.Clamp(LookVertical, minAngle, maxAngle);
                transform.Rotate(new Vector3(LookVertical, 0, 0) * Time.deltaTime * Speed, Space.Self);
            }
        }
        if (LookVertical < 0)
        {
            if (transform.localRotation.x >= -0.4f)
            {
                //LookVertical = Mathf.Clamp(LookVertical, minAngle, maxAngle);
                transform.Rotate(new Vector3(LookVertical, 0, 0) * Time.deltaTime * Speed, Space.Self);
            }
        }
        if (MouseLookVertical > 0)
        {
            if (transform.localRotation.x <= 0.31f)
            {
                // MouseLookVertical = MouseLookVertical * Time.deltaTime * Speed;
                //MouseLookVertical = Mathf.Clamp(MouseLookVertical, minAngle, maxAngle);
                //transform.Rotate(new Vector3(MouseLookVertical, 0, 0), Space.Self);
                transform.Rotate(new Vector3(MouseLookVertical, 0, 0) * Time.deltaTime * Speed, Space.Self);
            }
        }
        if (MouseLookVertical < 0)
        {
            if (transform.localRotation.x >= -0.4f)
            {
                // MouseLookVertical = MouseLookVertical * Time.deltaTime * Speed;
                //MouseLookVertical = Mathf.Clamp(MouseLookVertical, minAngle, maxAngle);
                //transform.Rotate(new Vector3(MouseLookVertical, 0, 0), Space.Self);
                transform.Rotate(new Vector3(MouseLookVertical, 0, 0) * Time.deltaTime * Speed, Space.Self);
            }
        }


    }
}