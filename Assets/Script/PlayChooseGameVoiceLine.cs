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

    bool alreadyPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        alreadyPlayed = (PlayerPrefs.GetInt("BackToLobby") == 1 && PlayerPrefs.GetInt("AlreadyPlayedChooseGame") == 1);
        if (!alreadyPlayed && other.CompareTag("Player"))
        {
            audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
            audioSource.Play();
            StartCoroutine(PlayScoreKeeperLine());
            PlayerPrefs.SetInt("AlreadyPlayedChooseGame", 1);
        }
    }
    IEnumerator PlayScoreKeeperLine()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = audioClipList[Random.Range(0, scorekeeperLines.Count)];
        audioSource.Play();
    }
}
