using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Shared gamestate
    public int currentLevel = 0;
    public int maxLevel = 2;
    public int score = 0;
    public bool isInMenu = true;

    public int maxCharges = 5;
    public int chargesRemaining = 0;
    public int currentCharge = 1;  // 1 = positive, -1 = negative
}
