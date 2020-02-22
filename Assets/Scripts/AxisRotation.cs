using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    [Range(0f, 90f)]
    public float maxRotation = 45;

    [Range(0f, 0.1f)]
    public float rotationSpeed = 0.05f;

    private Quaternion m_targetRotation = Quaternion.identity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Vertical") * maxRotation;
        float z = -Input.GetAxis("Horizontal") * maxRotation;

        m_targetRotation = Quaternion.Euler(x, 0, z);
        transform.rotation = Quaternion.Slerp(transform.rotation, m_targetRotation, rotationSpeed);
    }
}
