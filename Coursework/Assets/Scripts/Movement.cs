using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public HealthScript HealthScript;
    public float Speed;
    public float LowSpeed;
    [HideInInspector] public float MovementSpeed;
    public float JumpMovement;
    private Vector3 MovementJump;
    public bool Jump { get; private set; }
    public Vector3 movement;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       
    }
    void Update()
    {
        if (HealthScript.Battery < 1)
        {
            MovementSpeed=LowSpeed;
        }
        else
        {
            MovementSpeed=Speed;
        }
    }
    private void FixedUpdate()
    {
        Rigidbody RB = GetComponent<Rigidbody>();
        float MoveVertical = Input.GetAxis("Vertical");
        float MoveHorizontal = Input.GetAxis("Horizontal");

    Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);

        if (MoveVertical != 0||MoveHorizontal !=0)
        {
            RB.AddRelativeForce(movement*MovementSpeed);

        }

    }

    void OnTriggerStay(Collider other)
    {
        Vector3 MovementJump = new Vector3(0.0f, JumpMovement, 0.0f);
        Rigidbody RB = GetComponent<Rigidbody>();
        bool Jump = Input.GetButtonDown("Jump");
        if (other.gameObject.layer == 11)
        {
            if (Jump == true)
            {
                RB.AddForce(MovementJump * JumpMovement);
            }
        }
    }       
}
 