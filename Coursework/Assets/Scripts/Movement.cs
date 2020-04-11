using System.Collections;
using System.Collections.Generic;
using UnityEngine; //These using statements allow libraries to be imported, in this case C sharp libraries and a Unity library

/*This script controls the movement of Player around the world using the inputs
 * from the game controller and the keyboard. There are two speeds of movement: Speed is the normal
 * speed and is set in the inspector. Low Speed is used when Player's battery is empty. Jump is
 * activated by space bar or the jump button on the controller and the jump height JumpMovement
 * is set in the inspector.
*/

public class Movement : MonoBehaviour { 
    public HealthScript HealthScript; // Battery variable is taken from HealthScript to set the speed
    public float Speed; 
    public float LowSpeed; 
    [HideInInspector] public float MovementSpeed; //The speed multiplier which is either equal to Speed or LowSpeed
    public float JumpMovement;
    private Vector3 MovementJump; //The jump action vector
    public bool Jump { get; private set; } //This is true when space bar pressed
    [HideInInspector] public Vector3 movement; //Movement of Player in the X and Z axis
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked; //Locks the cursor in position in centre of screen and hides it
                                                  
        Cursor.visible = false; // this is for Linux in place of the command above it
    }
    void Update()
    {
        if (HealthScript.Battery < 1) //Sets the movements speed to normal or low depending on battery level
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
        Rigidbody RB = GetComponent<Rigidbody>(); //Gets the player's rigidbody and assigns it to the RB variable
        float MoveVertical = Input.GetAxis("Vertical"); //Gets movement input from keyboard or controller - Z axis
        float MoveHorizontal = Input.GetAxis("Horizontal"); //Gets movement input from keyboard or controller - X axis
        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical); //Combines the two inputs into a vector3

        if (MoveVertical != 0||MoveHorizontal !=0) //Adds relative force to Player if there is a movemement input
        {
            RB.AddRelativeForce(movement*MovementSpeed); //Adds the input to the Player's existing movement
            // It is relative because it works with the rotation of the player so movement is relative to the player not the world

        }

    }

    void OnTriggerStay(Collider other) //Jump function. Only works when player in contact with ground and jump button pressed 
    {
        Vector3 MovementJump = new Vector3(0.0f, JumpMovement, 0.0f); //Sets movement Vector3 for a Jump - Y axis only
        Rigidbody RB = GetComponent<Rigidbody>();
        bool Jump = Input.GetButtonDown("Jump"); //Checks for jump button pressed
        if (other.gameObject.layer == 11) //Player only jumps if in contact with layer 11 which is the ground
        {
            if (Jump == true) //Only jumps if jump button pressed
            {
                RB.AddForce(MovementJump * JumpMovement); //Adds jump force to player
            }
        }
    }       
}
 