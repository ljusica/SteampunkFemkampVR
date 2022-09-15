using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClownKnockEvent
{
    public delegate void KnockDown(GameObject clown);
    public static event KnockDown knockDown;

    public static void TriggerKnock(GameObject clown)
    {
        knockDown?.Invoke(clown);
    }
}
