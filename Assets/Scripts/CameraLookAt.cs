using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public GameObject cube;
    public Transform cubeTransform;
    void Start()
    {
        
    }

    void Update()
    {
        //transform.LookAt(cube.transform);
        transform.LookAt(cubeTransform);
    }
}
