using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public GameObject positionTarget;

    Vector3 offset;
    Quaternion rotationDiff;
    float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        // Update smooth rotation of the camera
        Vector3 targetDirection = target.transform.position - gameObject.transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(gameObject.transform.forward, targetDirection, singleStep, 0.0f);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.LookRotation(newDirection), singleStep);

        // Update position
        Vector3 desiredPosition = target.transform.position + offset;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, positionTarget.transform.position, singleStep);
    }
}
