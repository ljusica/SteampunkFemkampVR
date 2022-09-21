using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public MoleManager moleManager;

    private void OnEnable()
    {
        moleManager.StartGame();
    }

    private void OnDisable()
    {
        moleManager.StopGame();
    }
}
