using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public List<Mole> moles = new List<Mole>();
    public delegate void GameOver(List<Mole> moles);
    public static GameOver gameOver;

    private float timer;
    private int moleAmount;
    private float buffer = 1f;
    private float points = 100;
    private bool molesUp = true;

    private void Start()
    {
        Mole.whack += WhackMole;
    }

    private void Update()
    {
        if(!molesUp)
        {
            if(Time.time > timer + buffer)
            {
                MolesUp();
                molesUp = true;
            }
        }
    }

    public void StartGame()
    {
        MolesUp();
        molesUp = true;
    }

    public void StopGame()
    {
        gameOver?.Invoke(moles);
        molesUp = true;
    }

    private void MolesUp()
    {
        moleAmount = Random.Range(1, moles.Count + 1);

        for (int i = 0; i < moleAmount; i++)
        {
            PickMole();
        }
    }

    private void WhackMole(Mole mole)
    {
        moles.Add(mole);
        ScoreManager.Instance.AddScore("WAM", points);
        if(moles.Count == 5)
        {
            molesUp = false;
            timer = Time.time;
        }
    }

    private void PickMole()
    {
        int rand = Random.Range(0, moles.Count);
        Mole tempMole = moles[rand];
        moles.Remove(tempMole);
        tempMole.Open();
    }

    private void OnDisable()
    {
        Mole.whack -= WhackMole;
    }
}
