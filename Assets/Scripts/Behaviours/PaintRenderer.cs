using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PaintRenderer : MonoBehaviour
{
    public float trigger;
    public Transform ball;

    LineRenderer paint;
    bool isDrawing;

    // Start is called before the first frame update
    void Start()
    {
        paint = GetComponent<LineRenderer>();
        Debug.Log($"{ball}");
        if (ball == null) ball = GameObject.Find("Ball").transform;
        Debug.Log($"{ball.name}");
        transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.back);

        paint.useWorldSpace = false;
        paint.alignment = LineAlignment.TransformZ;
    }

    // Update is called once per frame
    void Update()
    {
        trigger = Input.GetAxis("Fire1");

        if (trigger > 0f)
        {
            if (!isDrawing)
            {
                paint.positionCount = 0;
                isDrawing = true;
            }

            // local position of this next point
            var pos = transform.InverseTransformPoint(ball.position);
            pos.z = -0.01f;
            // add it
            paint.positionCount += 1;
            paint.SetPosition(paint.positionCount - 1, pos);
        }
        else
        {
            isDrawing = false;
        }
    }
}
