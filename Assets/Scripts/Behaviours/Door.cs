using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ITriggerable
{
    public int targetCharge = 1;
    public float openHeight = -0.1f;
    public float closedHeight = 0.1f;
    public float moveTimeSeconds = 1f;

    private void Start()
    {
        StartCoroutine(Move(closedHeight));
    }

    public void OnChargeChange(Capacitor capa)
    {
        if (capa.currentCharge == targetCharge)
        {
            StartCoroutine(Move(openHeight));
        }
        else
        {
            StartCoroutine(Move(closedHeight));
        }
    }

    private IEnumerator Move(float targetHeight)
    {
        const int steps = 100;
        float translateStep = (targetHeight - transform.localPosition.y) / steps;
        for(int i = 0; i < steps; i++)
        {
            transform.Translate(0, translateStep, 0);
            yield return new WaitForSeconds(moveTimeSeconds / steps);
        }
    }
}
