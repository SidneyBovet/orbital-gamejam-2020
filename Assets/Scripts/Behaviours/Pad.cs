using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    public enum Polarity {
        POSITIVE,
        NEGATIVE
    }

    public Polarity polarity;
    public Material mMatPositiveCharge;
    public Material mMatNegativeCharge;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        // Verify charge, apply correct material
        if (polarity == Polarity.POSITIVE)
        {
            renderer.material = mMatPositiveCharge;
        }
        else
        {
            renderer.material = mMatNegativeCharge;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (polarity == Polarity.POSITIVE)
        {
            GameManager.Instance.currentCharge = 1;
        }
        else
        {
            GameManager.Instance.currentCharge = -1;
        }
    }
}
