using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorMotion : MonoBehaviour
{
    bool isOpen;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wizard" || other.gameObject.tag == "NPC")
        {
            isOpen = true;
            animator.SetTrigger("SlidingDoorOpen");
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (isOpen)
        {
            isOpen = false;
            animator.SetTrigger("SlidingDoorClose");
        }
    }
}
