using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCapa : Capacitor
{
    public override void OnChargeChanged()
    {
        // nothing to do
    }

    public override void OnContact(Capacitor other)
    {
        // nothing to do?
    }

    // Start is called before the first frame update
    void Start()
    {
        capacity = int.MaxValue;
        currentCharge = int.MaxValue;
    }
}
