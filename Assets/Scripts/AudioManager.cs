using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    /*
     Planning:
     0: play once, menu
     1: loop
     2: play once, credits
     3: loop
     4: play once, short transition
     5: loop
     */

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            GameManager.Instance.currentLevel += 1;
            NextLevel();
        }
    }

    public AudioClip[] clips;

    private AudioSource m_audioSource;
    // Start is called before the first frame update
    void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    { 
        Debug.Log("AudioManager start");
        DontDestroyOnLoad(this);
        m_audioSource = GetComponent<AudioSource>();

        if (clips.Length != 6) Debug.LogError("There should be exactly 6 audio clips.");

        Debug.Log("Current level: " + GameManager.Instance.currentLevel);
        switch (GameManager.Instance.currentLevel)
        {
            case 0:
                // start with clip 0, then loop clip 1
                m_audioSource.clip = clips[0];
                m_audioSource.loop = false;
                m_audioSource.Play();
                StartCoroutine(GoToNextTrackAfterThisOne(1, true));
                break;
            case 1:
                // creadits during clip 2, then loop clip 3
                StartCoroutine(GoToNextTrackAfterThisOne(2, false));
                break;
            case 2:
                // start with clip 4, then loop clip 5
                StartCoroutine(GoToNextTrackAfterThisOne(4, false));
                break;
            default:
                break;
        }
    }

    private IEnumerator GoToNextTrackAfterThisOne(int nextTrack, bool loop)
    {
        // wait for our clip to be next
        while (m_audioSource.clip != clips[nextTrack - 1])
        {
            Debug.Log($"Track {nextTrack} isn't next, waiting for this one to finish");
            yield return new WaitForSeconds(m_audioSource.clip.length - m_audioSource.time + 0.5f);
        }

        // we'll take care of the end of that clip, don't loop
        m_audioSource.loop = false;

        // wait for it to be almost done
        Debug.Log($"Source is {m_audioSource.clip.length}, we already played {m_audioSource.time} of it, sleeping for another {m_audioSource.clip.length - m_audioSource.time - 0.1f}.");
        yield return new WaitForSeconds(m_audioSource.clip.length - m_audioSource.time);

        Debug.Log($"Starting song {nextTrack}");
        m_audioSource.clip = clips[nextTrack];
        m_audioSource.loop = loop;
        if (!loop)
        {
            // Next one loops for sure (right?)
            StartCoroutine(GoToNextTrackAfterThisOne(nextTrack + 1, true));
        }

        m_audioSource.Play();
    }
}
