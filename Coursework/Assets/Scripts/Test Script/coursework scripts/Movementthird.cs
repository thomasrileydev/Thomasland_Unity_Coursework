using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementthird : MonoBehaviour {
    public float Speed;
    public float JumpMovement;
    private Vector3 MovementJump;
    public bool Jump { get; private set; } 
    private void FixedUpdate()
    {
        Rigidbody RB = GetComponent<Rigidbody>();
        float MoveVertical = Input.GetAxis("Vertical");
        float MoveHorizontal = Input.GetAxis("Horizontal");
        Vector3 Movement = new Vector3(MoveHorizontal*transform.forward.x, 0.0f, MoveVertical*transform.forward.z);
        if (MoveVertical != 0)
        {
            RB.velocity = transform.forward * Speed * MoveVertical;
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
 