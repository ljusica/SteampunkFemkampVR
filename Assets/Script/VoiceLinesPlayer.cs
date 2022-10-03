using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLinesPlayer : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> lines;
    [SerializeField]
    AudioSource voiceSource;
    [SerializeField]
    List<AudioClip> mockLines;
    [SerializeField]
    AudioClip randomFailLinesTut;
    [SerializeField]
    AudioClip randomFailLinesMock;

    void Start()
    {
        PlayerPrefs.SetInt("BackToLobby", 1);
        StartCoroutine(PlayTutorialLine());
    }
    IEnumerator PlayTutorialLine()
    {
        yield return new WaitForSeconds(3);
        if(randomFailLinesTut != null && Random.Range(0,100)==0)
        {
            voiceSource.clip = randomFailLinesTut;
        }
        else
        {
            voiceSource.clip = lines[Random.Range(0, lines.Count)];
        }
        voiceSource.Play();
    }
    public void PlayMockLine()
    {
        if (randomFailLinesMock != null && Random.Range(0, 100) == 0)
        {
            voiceSource.clip = randomFailLinesMock;
        }
        else
        {
            voiceSource.clip = mockLines[Random.Range(0, mockLines.Count)];
        }
        
        voiceSource.Play();
    }
}
