using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceCapa : Capacitor
{
    public override void OnContact(Capacitor other)
    {
        int desiredEndOtherCharge = other.currentCharge + this.currentCharge;

        int actualEndOtherCharge = Mathf.Clamp(desiredEndOtherCharge, -other.capacity, other.capacity);

        this.currentCharge += other.currentCharge - actualEndOtherCharge;
        other.currentCharge = actualEndOtherCharge;
    }

    public override void OnChargeChanged()
    {
        //gameObject.GetComponentInChildren<TextMesh>().text = currentCharge.ToString();

        if (currentCharge < 0)
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        else if (currentCharge > 0)
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        else
            gameObject.GetComponent<Renderer>().material.color = Color.grey;
    }
}
