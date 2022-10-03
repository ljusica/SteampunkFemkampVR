using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChooseGameVoiceLine : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> audioClipList;
    [SerializeField]
    List<AudioClip> scorekeeperLines;

    static bool alreadyPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed && other.CompareTag("Player"))
        {
            audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
            audioSource.Play();
            StartCoroutine(PlayScoreKeeperLine());
            alreadyPlayed = true;
        }
    }
    IEnumerator PlayScoreKeeperLine()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = audioClipList[Random.Range(0, scorekeeperLines.Count)];
        audioSource.Play();
    }
}
