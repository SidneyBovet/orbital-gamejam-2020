using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public float introTime = 2f;
    public float creaditsTime = 6f;
    public float transitionTime = 1f;

    public Renderer introPlane;
    public Renderer creditsPlane;

    private void Start()
    {
        StartCoroutine(PlayIntro());
    }

    private IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(introTime);
        yield return Fade(introPlane, 0f);
    }

    /// <summary>
    /// Fades in and out the credits object, all within creaditsTime (including transitionTime)
    /// </summary>
    public IEnumerator StartCreditsAndLoadNextLevel()
    {
        yield return Fade(creditsPlane, 1f);
        yield return new WaitForSeconds(creaditsTime - transitionTime);
        StartCoroutine(FindObjectOfType<LevelEnd>().LoadNextLevel(GameManager.Instance.currentLevel, 0f));
    }

    public IEnumerator Fade(Renderer plane, float targetAlpha)
    {
        const int steps = 20;
        float alphaStep = (targetAlpha - plane.material.color.a) / steps;
        for (int i = 0; i < steps; i++)
        {
            var color = plane.material.color;
            color.a += alphaStep;
            plane.material.color = color;
            yield return new WaitForSeconds(transitionTime / steps);
        }

        var finalColor = plane.material.color;
        finalColor.a = targetAlpha;
        plane.material.color = finalColor;
    }
}
