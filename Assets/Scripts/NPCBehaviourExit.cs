using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviourExit : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent theAgent;
    bool isOutOfMaze;

    // Start is called before the first frame update
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        theAgent.SetDestination(target.transform.position);
        GetComponent<Animation>().Play("Wizard Idle");
        isOutOfMaze = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isOutOfMaze)
            GetComponent<Animation>().Play("Standard Walk");
        else
            GetComponent<Animation>().Play("Wizard Idle");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(target.tag))
            isOutOfMaze = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(target.tag))
            isOutOfMaze = true;
    }
}
