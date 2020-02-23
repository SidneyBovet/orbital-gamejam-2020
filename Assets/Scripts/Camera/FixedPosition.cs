using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    public GameObject target;
    public GameObject chargeIndicator;

    float cameraRotation;
    Vector3 indicatorOffset;
    Quaternion rotation;
    TextMesh indicator;

    void Start()
    {
        rotation = target.transform.rotation;
        indicatorOffset = chargeIndicator.transform.position - target.transform.position;
        indicator = chargeIndicator.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.transform.position;

        chargeIndicator.transform.position = target.transform.position + indicatorOffset;
        indicator.text = "" + GameManager.Instance.currentCharge;

        // Camera rotation
        float cameraRotation = -Input.GetAxis("Mouse X") * 80;
        gameObject.transform.RotateAround(target.transform.position, Vector3.up, cameraRotation * Time.deltaTime);
    }
}
