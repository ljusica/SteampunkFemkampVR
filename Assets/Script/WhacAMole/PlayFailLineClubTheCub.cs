using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFailLineClubTheCub : MonoBehaviour
{
    [SerializeField]
    VoiceLinesPlayer voiceLinesPlayer;

    private void OnEnable()
    {
        StartCoroutine(PlayFailLine());
    }
    IEnumerator PlayFailLine()
    {
        yield return new WaitForSeconds(Random.Range(4, 10));
        voiceLinesPlayer.PlayMockLine();
        StartCoroutine(PlayFailLine());
    }
}
