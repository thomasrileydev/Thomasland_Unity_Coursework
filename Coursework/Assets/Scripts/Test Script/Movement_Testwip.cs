using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Testwip : MonoBehaviour {
    public float Speed;
    public float JumpValue;
    private Vector3 GravityMovement;
    private Vector3 MovementJump;
    private float JumpMovement;
    public bool Jump { get; private set; }
    public Transform Simpleman;

    private void FixedUpdate()
    {
        Rigidbody RB = GetComponent<Rigidbody>();
        GravityMovement = RB.GetPointVelocity(Simpleman.position);
        float MoveVertical = Input.GetAxis("Vertical");
        float MoveHorizontal = Input.GetAxis("Horizontal");
        Vector3 Movement = new Vector3(MoveHorizontal, JumpMovement, MoveVertical);
        RB.velocity= (Movement * Speed);







    }
    void OnTriggerStay(Collider other)
    {
        
        Rigidbody RB = GetComponent<Rigidbody>();
        bool Jump = Input.GetButtonDown("Jump");
        if (other.gameObject.CompareTag("Ground"))
        {
            if (Jump == true)
            {
                JumpMovement = JumpValue;
            }
        }
        else
        {
            RB.velocity = (GravityMovement);

        }

    }
    public void LateUpdate()
    {
    if (Jump == true)
        {
            JumpMovement = 0;
        }
    }

}
