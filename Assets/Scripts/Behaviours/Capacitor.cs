using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacitor : MonoBehaviour
{
    public int capacity;

    int chargeDiff;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            chargeDiff = GameManager.Instance.chargesRemaining - GameManager.Instance.maxCharges;

            if (chargeDiff < 0)
            {
                // Require charges
                if (Mathf.Abs(chargeDiff) > capacity)
                {
                    // Transfer all charges, depleted
                    GameManager.Instance.chargesRemaining += capacity;
                    capacity = 0;
                }
                else
                {
                    // Transfer difference of charges
                    capacity -= Mathf.Abs(chargeDiff);
                    capacity = Mathf.Max(0, capacity);
                    GameManager.Instance.chargesRemaining += Mathf.Abs(chargeDiff);
                }
            }
        }
    }
}
