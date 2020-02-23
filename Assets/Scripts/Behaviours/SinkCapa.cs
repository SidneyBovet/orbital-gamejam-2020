using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkCapa : Capacitor
{
    public GameObject connected = null;

    public override void OnContact(Capacitor other)
    {
        // Adapt charge (steal from other)
        int desiredEndCharge = this.currentCharge + other.currentCharge;

        int actualEndCharge = Mathf.Clamp(desiredEndCharge, -capacity, capacity);

        other.currentCharge += this.currentCharge - actualEndCharge;
        this.currentCharge = actualEndCharge;

        // Notify connected trigger if any
        connected?.GetComponent<ITriggerable>()?.OnChargeChange(this);
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

        gameObject.GetComponent<AudioSource>().Play();
    }
}
