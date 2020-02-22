using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject chargeHolder;

    [Range(0,5)]
    public float nextLevelLoadDelay = 1f;

    private bool m_nextSceneLoading = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check that the ball has entered
        if (other.gameObject.name == "Ball"
            && !m_nextSceneLoading)
        {
            // Game is won, move to the next level
            Debug.Log("Level is won");
            GameManager.Instance.currentLevel += 1;
            StartCoroutine(LoadNextLevel(GameManager.Instance.currentLevel));
        }
    }

    private IEnumerator LoadNextLevel(int levelNumber)
    {
        if (!m_nextSceneLoading)
        {
            m_nextSceneLoading = true;

            Debug.Log("Loading level " + levelNumber + " in " + nextLevelLoadDelay + "s");
            yield return new WaitForSeconds(nextLevelLoadDelay);

            SceneManager.LoadScene("Level-" + levelNumber);
        }
    }
}
