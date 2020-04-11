/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotationOLD2 : MonoBehaviour {
    public Transform Target;
    public float Speed;

    public float RotationSpeed;

    
    private void FixedUpdate()
    {

        float LookHorizontal = Input.GetAxis("Right Stick Horizontal");
        float MouseLookHorizontal = Input.GetAxis("Mouse X");
        float LookVertical = Input.GetAxis("Right Stick Vertical");
        float MouseLookVertical = Input.GetAxis("Mouse Y");
       
        Vector3 TargetVectorVertical = new Vector3(Target.localPosition.x, LookVertical*RotationSpeed, Target.localPosition.z);
        Vector3 TargetVectorVerticalMouse = new Vector3(Target.localPosition.x, MouseLookVertical * RotationSpeed, Target.localPosition.z);

        if (LookVertical != 0)
        {
            Target.localPosition = TargetVectorVertical;
        }
        else if(MouseLookVertical != 0)
        {
            Target.localPosition = TargetVectorVerticalMouse;
        }
        else
        {
            Target.localPosition = new Vector3(Target.localPosition.x, 0.0f, Target.localPosition.z);
        }
        if (LookHorizontal != 0)
        {
            transform.Rotate(new Vector3(0, LookHorizontal, 0) * Time.deltaTime * Speed, Space.World);
        }
        if (MouseLookVertical != 0)
        {
            transform.Rotate(new Vector3(0, MouseLookHorizontal, 0) * Time.deltaTime * Speed, Space.World);
        }
    
    }
}*/
       