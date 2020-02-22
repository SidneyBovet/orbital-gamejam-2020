using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    public GameObject target;
    public float cameraRotation;
    Quaternion rotation;

    void Start()
    {
        rotation = target.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.transform.position;

        // Camera rotation
        float cameraRotation = -Input.GetAxis("Mouse X") * 80;
        gameObject.transform.RotateAround(target.transform.position, Vector3.up, cameraRotation * Time.deltaTime);
    }
}
