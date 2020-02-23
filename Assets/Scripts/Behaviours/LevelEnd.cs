using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject chargeHolder;

    AudioSource source;

    [Range(0,5)]
    public float nextLevelLoadDelay;

    private bool m_nextSceneLoading = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check that the ball has entered
        if (other.gameObject.name == "Ball"
            && !m_nextSceneLoading)
        {
            m_nextSceneLoading = true;

            // Game is won, move to the next level
            source.Play();
            GameManager.Instance.currentLevel += 1;

            if (GameManager.Instance.currentLevel > GameManager.Instance.maxLevel)
            {
                GameManager.Instance.currentLevel = 0;
            }

            Debug.Log("Loadig next -> " + GameManager.Instance.currentLevel);

            if (GameManager.Instance.currentLevel == 1)
            {
                StartCoroutine(FindObjectOfType<TransitionManager>().StartCreditsAndLoadNextLevel());
            }
            else
            {
                StartCoroutine(LoadNextLevel(GameManager.Instance.currentLevel, nextLevelLoadDelay));
            }
        }
    }

    public IEnumerator LoadNextLevel(int levelNumber, float seconds)
    {
        Debug.Log($"Loading level {levelNumber} in {seconds}s");
        yield return new WaitForSeconds(seconds);

        FindObjectOfType<AudioManager>()?.NextLevel();

        SceneManager.LoadScene("Level-" + levelNumber);
    }
}
