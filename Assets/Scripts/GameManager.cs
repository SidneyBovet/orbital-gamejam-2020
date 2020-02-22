using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    static readonly object padlock = new object();

    GameManager() { }  // Block instantiation

    // Prevent deleting this object between scene changes
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameManager();
                    }
                }
            }
            return instance;
        }
    }

    // Shared gamestate
    public int currentLevel = 0;
    public int score = 0;
    public bool isInMenu = true;

    public void reset()
    {
        currentLevel = 0;
        score = 0;
        isInMenu = true;
    }
}
