using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackToLobbyLine : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> audioClipList;

    bool alreadyPlayed = false;
    void Start()
    {
        alreadyPlayed = (PlayerPrefs.GetInt("BackToLobby") == 1);
        if (alreadyPlayed)
            Invoke(nameof(PlayBackToLobbyVoiceLine),3);
    }
    void PlayBackToLobbyVoiceLine()
    {
        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        audioSource.Play();
        PlayerPrefs.SetInt("BackToLobby", 0);
    }
}
