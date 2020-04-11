
using UnityEngine;

public class RotationCodeNF:MonoBehaviour
{
    public float Speed;
    public Transform transform;
    private void FixedUpdate()
	{
        transform.rotation = Quaternion.Euler(Input.GetAxis("Right Stick Horizontal")*Speed, Input.GetAxis("Right Stick Vertical")*Speed,0);

    }
}
