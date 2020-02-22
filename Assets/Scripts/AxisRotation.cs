using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Vertical");
        float z = -Input.GetAxis("Horizontal");

        Debug.Log("x: " + x + ", z: " + z);

        transform.Rotate(x, 0, z);
    }
}
