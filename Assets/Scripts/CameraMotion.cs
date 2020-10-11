using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMotion : MonoBehaviour
{
    private float _speedForward, _speedSide;
    private float _angularSpeed = 1f;
    private float _rotationAngleX, _rotationAngleY;
    private CharacterController _characterController;
    private float _minX, _minZ, _maxX, _maxZ;

    // Start is called before the first frame update
    void Start()
    {
        _speedForward = 0f;
        _speedSide = 0f;
        _rotationAngleX = 0f;
        _rotationAngleY = 0f;

        _characterController = GetComponent<CharacterController>();
        // _minX = Terrain.activeTerrain.terrainData.bounds.min.x;
        // _minZ = Terrain.activeTerrain.terrainData.bounds.min.z;
        // _maxX = Terrain.activeTerrain.terrainData.bounds.min.x + Terrain.activeTerrain.terrainData.size.x;
        // _maxZ = Terrain.activeTerrain.terrainData.bounds.min.z + Terrain.activeTerrain.terrainData.size.z;

    }

    // Update is called once per frame
    void Update()
    {
        // get mouse X-coordinate
        float mouse_x = Input.GetAxis("Mouse X");
        // get mouse Y-coordinate
        float mouse_y = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.W))
            _speedForward = 2f;
        else if (Input.GetKey(KeyCode.S))
            _speedForward = -2f;
        else if (Input.GetKey(KeyCode.A))
            _speedSide = -2f;
        else if (Input.GetKey(KeyCode.D))
            _speedSide = 2f;
        else {
            _speedForward = 0f;
            _speedSide = 0f;
        }
        // sets sight direction by means of transform.Rotate
        _rotationAngleX += mouse_x * _angularSpeed * Time.deltaTime;
        _rotationAngleY += mouse_y * _angularSpeed * Time.deltaTime * -1;
        transform.Rotate(0, _rotationAngleX, 0);
        
        // transform.Translate(Vector3.forward * Time.deltaTime*_speedForward);


        // Translate is one of transformatioins that uses Vector3
        Vector3 point = Vector3.forward * Time.deltaTime * _speedForward;
        if (transform.position.x <= _minX || transform.position.x >= _maxX || transform.position.z <= _minZ ||
           transform.position.z >= _maxZ) point.y = 0;
        else // update height to terrain height in point (position.x,,position.z)
        {
            Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
            point.y = 1.6f + Terrain.activeTerrain.SampleHeight(pos) - transform.position.y; // delta in Y direction
        }
        //        transform.Translate(point);

        // we shall use CharacterController to move and to stop if camera collides with another object
        Vector3 direction = transform.TransformDirection(Vector3.forward * Time.deltaTime * _speedForward);
        _characterController.Move(direction);
        Vector3 directionSide = transform.TransformDirection(Vector3.right * Time.deltaTime * _speedSide);
        _characterController.Move(directionSide);
    }
}