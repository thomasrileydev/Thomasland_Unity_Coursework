/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotationOLD : MonoBehaviour {



    public float RotationSpeed;

  
    private void FixedUpdate()
    {
        float LookHorizontal = Input.GetAxisRaw("Right Stick Horizontal");
        float MouseLookHorizontal = Input.GetAxis("Mouse X");
        float LookVertical = Input.GetAxisRaw("Right Stick Vertical");
        float MouseLookVertical = Input.GetAxis("Mouse Y");
        if (transform.rotation.y > 0.9f || transform.rotation.y < -0.9f)
        {
            LookVertical = 0;
        }
        Rigidbody RB = GetComponent<Rigidbody>();
        float step = RotationSpeed * Time.deltaTime;
        Vector3 CurrentVector = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Vector3 TargetVectorVertical = new Vector3(
           0.0f
            ,
            transform.rotation.y + LookVertical
            ,
            0.0f);

        Vector3 TargetVectorHorizontal = new Vector3(
            transform.rotation.x
            ,
            transform.rotation.y + (LookHorizontal * RotationSpeed)
            ,
        Vector3 newDirVertical = Vector3.RotateTowards(transform.forward, TargetVectorVertical, step, 0.0f);
        Vector3 newDirHorizontal = Vector3.RotateTowards(transform.forward, TargetVectorHorizontal, step, 0.0f);
        if (LookVertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(newDirVertical);
        }
        else if (LookHorizontal != 0)
                transform.rotation = Quaternion.Euler(newDirHorizontal);
        }
}*/
       