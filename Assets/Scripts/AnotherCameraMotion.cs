using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherCameraMotion : MonoBehaviour
{
    float angularSpeed;
    float verticalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        angularSpeed = 6f;
        verticalSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), -1 * Input.GetAxis("Mouse Y"));
    }
}
