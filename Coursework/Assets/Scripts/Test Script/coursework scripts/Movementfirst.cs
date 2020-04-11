using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementfirst : MonoBehaviour {
    public float Speed;
    public float JumpMovement;
    private Vector3 MovementJump;
    public bool Jump { get; private set; } 
    void FixedUpdate()
    {
        Rigidbody RB = GetComponent<Rigidbody>();
        float MoveVertical = Input.GetAxis("Vertical");
        float MoveHorizontal = Input.GetAxis("Horizontal");
        Vector3 Movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        if (MoveVertical != 0||MoveHorizontal!=0)
        {
            RB.AddForce(Movement*Speed);
        }

    }

    void OnTriggerStay(Collider other)
    {
        Vector3 MovementJump = new Vector3(0.0f, JumpMovement, 0.0f);
        Rigidbody RB = GetComponent<Rigidbody>();
        bool Jump = Input.GetButtonDown("Jump");
        if (other.gameObject.CompareTag("Ground"))
        {
            if (Jump == true)
            {
                RB.AddForce(MovementJump * JumpMovement);
            }
        }
    }
}
 