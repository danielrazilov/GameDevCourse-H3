using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDoorMption : MonoBehaviour
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
        if (other.CompareTag("Wizard") || other.CompareTag("Paladin") || other.CompareTag("Ganfaul"))
        {
            isOpen = true;
            animator.SetTrigger("StoneDoorOpen");
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (isOpen)
        {
            animator.SetTrigger("StoneDoorClose");
            isOpen = false;
        }
    }
}
