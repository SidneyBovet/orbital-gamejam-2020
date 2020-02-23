using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintRenderer : MonoBehaviour
{
    LineRenderer paint;
    public float trigger;

    // Start is called before the first frame update
    void Start()
    {
        paint = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        trigger = Input.GetAxis("Fire1") * 40.0f;
    }
}
