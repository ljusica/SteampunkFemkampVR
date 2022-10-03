using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFailLineEyeBall : MonoBehaviour
{
    [SerializeField]
    VoiceLinesPlayer voiceLinesPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            voiceLinesPlayer.PlayMockLine();
        }
    }
}
