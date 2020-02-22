using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject chargeHolder;
    private int currentLevel = GameManager.Instance.currentLevel;

    private void OnTriggerEnter(Collider other)
    {
        // Check that the ball has entered
        if (other.gameObject.name == "Ball") {
            // Game is won, move to the next level
            Debug.Log("Level is won");

            GameManager.Instance.currentLevel = currentLevel + 1;
        }
    }
}
