using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Capacitor : MonoBehaviour
{
    public int capacity;
    public int currentCharge;

    public abstract void OnContact(Capacitor other);

    public abstract void OnChargeChanged();

    private void Start()
    {
        OnChargeChanged();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherCapa = other.GetComponent<Capacitor>();

        if (otherCapa != null)
        {
            OnContact(otherCapa);
            otherCapa.OnChargeChanged();
            OnChargeChanged();
        }
    }
}
