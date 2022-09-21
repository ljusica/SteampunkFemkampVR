using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public List<Mole> moles = new List<Mole>();
    private float timer;
    private float buffer = 2;

    private void Start()
    {
        Mole.whack += ResetTimer;
        timer = Time.time;
    }

    private void Update()
    {
        if (Time.time > timer + buffer)
        {
            if(moles.Count > 0)
                PickMole();
            timer = Time.time;
        }
    }

    private void ResetTimer(Mole mole)
    {
        moles.Add(mole);
        PickMole();
        timer = Time.time;
    }

    private void PickMole()
    {
        int rand = Random.Range(0, moles.Count);
        Mole tempMole = moles[rand];
        moles.Remove(tempMole);
        tempMole.Open();
    }
}
