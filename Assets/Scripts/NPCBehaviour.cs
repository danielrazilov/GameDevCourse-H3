using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour
{
    public GameObject targets;
    private GameObject _currentTarget;
    NavMeshAgent theAgent;
    List<GameObject> childTargets = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        bool skipParent = false;
        Transform[] allChildren = targets.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (skipParent)
                childTargets.Add(child.gameObject);
            skipParent = true;
        }

        theAgent = GetComponent<NavMeshAgent>();

        _currentTarget = childTargets[getRandomTarget(childTargets.Count)];
        theAgent.SetDestination(_currentTarget.transform.position);
        //Debug.Log(_currentTarget.tag);
        //Debug.Log(childTargets.Count);

        if (gameObject.CompareTag("Wizard"))
            GetComponent<Animation>().Play("Wizard Idle");
        else if (gameObject.CompareTag("Paladin"))
            GetComponent<Animation>().Play("Paladin Idle");
        else
            GetComponent<Animation>().Play("Ganfaul Idle");


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Wizard"))
            GetComponent<Animation>().Play("Standard Walk");
        else if (gameObject.CompareTag("Paladin"))
            GetComponent<Animation>().Play("Paladin Run");
        else
            GetComponent<Animation>().Play("GanfaulWalking");

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_currentTarget.tag))
        {
            _currentTarget = childTargets[getRandomTarget(childTargets.Count)];
            theAgent.SetDestination(_currentTarget.transform.position);
            Debug.Log(_currentTarget.tag);
        }

    }

    private int getRandomTarget(int numOfTargets)
    {
        System.Random random = new System.Random();
        return random.Next(numOfTargets);
    }
}
