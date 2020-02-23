using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    [Range(0f, 90f)]
    public float maxRotation = 45;
    [Range(0f, 0.1f)]
    public float rotationSpeed = 0.05f;
    //public Transform ballPosition;
    public Transform mainCamera;

    private Quaternion m_targetRotation = Quaternion.identity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Vertical") * maxRotation;
        float z = -Input.GetAxis("Horizontal") * maxRotation;

        // Option 0 - nope
        //m_targetRotation = Quaternion.Euler(x, 0, z);
        //transform.rotation = Quaternion.Slerp(transform.rotation, m_targetRotation, rotationSpeed);

        // grab main camera if we don't have it already
        if (mainCamera == null) mainCamera = Camera.main.transform;

        //compute proper axes
        var xDir = ProjectOntoPlane(mainCamera.right, Vector3.up);
        var zDir = ProjectOntoPlane(mainCamera.up, Vector3.up);

        RotateAround(Vector3.zero, xDir, zDir, x, z);
    }

    void RotateAround(Vector3 origin, Vector3 xDir, Vector3 zDir, float xRot, float zRot)
    {
        Debug.DrawRay(origin, xDir, Color.red);
        Debug.DrawRay(origin, zDir, Color.blue);

        // Option 1
        var rotation = Quaternion.AngleAxis(xRot, xDir) * Quaternion.AngleAxis(zRot, zDir);
        m_targetRotation = rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, m_targetRotation, rotationSpeed);


        // Option 2
        // todo: lerp the Rots towards 0 ?
        //transform.rotation = Quaternion.identity;
        //transform.RotateAround(origin, xDir, xRot);
        //transform.RotateAround(origin, zDir, zRot);


    }

    private Vector3 ProjectOntoPlane(Vector3 u, Vector3 n)
    {
        var projOnN = Vector3.Dot(u, n) * n.normalized;
        return u - projOnN;
    }
}
