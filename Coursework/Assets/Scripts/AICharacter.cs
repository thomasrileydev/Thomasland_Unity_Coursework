using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*This script controls the AI character movement. It uses a Navmesh and Navmesh agent to navigate a path
 * to Player avoiding obstacles. Some variables are set in the Navmesh agent and do not appear in the script.
 * A 1 second delay is built in every time it recalculates the path, this is to improve performance as the
 * path calculation was happening every frame slowing it down significantly. I used the profiler to discover this.
 * It also improves the game play because it allows the Player to avoid the Enemy which it couldn't escape before.
 */

public class AICharacter : MonoBehaviour
{
    
    //public float JumpMovement;
    //public bool Jump { get; private set; }

    public Collider PlayerCollider;

    public Transform Player;
    //public Collider ForestBoundary;
    private NavMeshPath path;
    
    public void Start()
    {
        path = new NavMeshPath();
        StartCoroutine(CalculatePath());
    }
    IEnumerator CalculatePath()
    {
        yield return new WaitForSeconds(1); //1 second delay
        Rigidbody RB = GetComponent<Rigidbody>();
        NavMeshAgent NMA = GetComponent<NavMeshAgent>();
        NavMesh.CalculatePath(RB.position, Player.position, NavMesh.AllAreas, path); //Calculates path using A* algorithm
        
        NMA.areaMask = NavMesh.AllAreas; //Enemy can access all areas
        NMA.CalculatePath(Player.position, path); //Calculates another path for the Navmesh agent
        NMA.SetDestination(Player.position); //Makes Player's location the destination
        StartCoroutine(CalculatePath()); //Recursion

    }

    /*I previously used this next part to make the Forest a safe place for Player. 
     * I did this because I didn't think that the enemy could negotiate the large
     * amount of trees but it failed to work because the Enemy got stuck at the
     * boundary of Forest and as soon as Player crossed back over the boundary they 
     * got killed immediately by the Enemy who was effectively always waiting for them */

    /*public void FixedUpdate()


    {

        Rigidbody RB = GetComponent<Rigidbody>();
        NavMeshAgent NMA = GetComponent<NavMeshAgent>();
        NavMesh.CalculatePath(RB.position, Player.position, NavMesh.AllAreas, path);
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

        NMA.areaMask = NavMesh.AllAreas;
        NMA.CalculatePath(Player.position, path);
        NMA.SetDestination(Player.position);
    }*/
    //if (other.gameObject.CompareTag("ForestBoundary"))
    /*{
        NMA.isStopped=true;

    }
    else
    {
        NMA.isStopped = false;
    } */

    /*private void jump(Collider other)
    {
        Vector3 MovementJump = new Vector3(0.0f, JumpMovement, 0.0f);
        Rigidbody RB = GetComponent<Rigidbody>();
        //I used this next line to allow Enemy to jump from one place to another but it never worked
        //probably because I did not configure it properly in Unity but it wasn't needed in the end
        OffMeshLink OML = GetComponent<OffMeshLink>();
        if (transform.position == OML.startTransform.position)
        {
            Jump = true;

        }
        if (other.gameObject.layer == 11)
        {
            if (Jump == true)
            {
                RB.AddForce(MovementJump * JumpMovement);
            }
        }


    }*/
}
