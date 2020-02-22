using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCapa : Capacitor
{
    public override void OnContact(Capacitor other)
    {
        // nothing here (source and sinks handle the computations)
    }

    public override void OnChargeChanged()
    {
        if (currentCharge < 0)
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        else if (currentCharge > 0)
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        else
            gameObject.GetComponent<Renderer>().material.color = Color.grey;
    }
}
