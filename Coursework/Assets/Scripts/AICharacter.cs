using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AICharacter : MonoBehaviour
{
    
    public float JumpMovement;
    
    public bool Jump { get; private set; }

    public Collider PlayerCollider;

    public Transform Player;
    public Collider ForestBoundary;
    private NavMeshPath path;
    


    public void Start()
    {
        path = new NavMeshPath();
        StartCoroutine(CalculatePath());
    }
    IEnumerator CalculatePath()
    {
        yield return new WaitForSeconds(1);
        Rigidbody RB = GetComponent<Rigidbody>();
        NavMeshAgent NMA = GetComponent<NavMeshAgent>();
        NavMesh.CalculatePath(RB.position, Player.position, NavMesh.AllAreas, path);
        
        NMA.areaMask = NavMesh.AllAreas;
        NMA.CalculatePath(Player.position, path);
        NMA.SetDestination(Player.position);
        StartCoroutine(CalculatePath());

    }

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
