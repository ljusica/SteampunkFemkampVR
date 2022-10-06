using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomVoiceLines : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> audioClipList;
    void Start()
    {
        StartCoroutine(PlayRandomLine());
    }

    IEnumerator PlayRandomLine()
    {
        yield return new WaitForSeconds(Random.Range(40 , 100));
        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        audioSource.Play();
        StartCoroutine(PlayRandomLine());
    }
}
