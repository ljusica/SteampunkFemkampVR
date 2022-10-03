using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFailLineTeddy : MonoBehaviour
{
    [SerializeField]
    VoiceLinesPlayer voiceLinesPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if(Random.Range(0,5) == 0)
                voiceLinesPlayer.PlayMockLine();
        }
    }
}
