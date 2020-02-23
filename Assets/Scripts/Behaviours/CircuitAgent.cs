using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitAgent : MonoBehaviour
{
    private List<Capacitor> connected = new List<Capacitor>();

    private void OnTriggerStay(Collider other)
    {
        var painter = GameObject.FindObjectOfType<PaintRenderer>();
        if (painter == null || !painter.IsDrawing)
        {
            connected.Clear();
            return;
        }

        var newCapa = other.GetComponent<Capacitor>();
        if (newCapa == null) return;

        if (connected.Contains(newCapa)) return;

        Debug.Log("Drawing and we hit a capa, adding it.");

        connected.Add(newCapa);

        foreach (var c in connected)
        {
            foreach (var cc in connected)
            {
                if (c != cc)
                {
                    Debug.Log($"Notifying {c.name} of contact from {cc.name}");
                    c.OnContact(cc);
                }
            }
        }
    }
}
