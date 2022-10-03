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
        yield return new WaitForSeconds(Random.Range(10, 25));
        voiceLinesPlayer.PlayMockLine();
        StartCoroutine(PlayFailLine());
    }
}
