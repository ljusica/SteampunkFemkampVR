using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public List<Mole> moles = new List<Mole>();
    private float timer;
    private float buffer = 1.5f;
    private float lastHitBuffer = 3;
    private Mole lastHit;

    private void Start()
    {
        Mole.whack += WhackMole;
        timer = Time.time;
    }

    private void Update()
    {
        if (Time.time > timer + buffer)
        {
            if(moles.Count > 0)
                PickMole();
        }

        if(Time.time > timer + lastHitBuffer)
        {
            lastHit = null;
        }
    }

    private void WhackMole(Mole mole)
    {
        moles.Add(mole);
        lastHit = mole;
    }

    private void PickMole()
    {
        int rand = Random.Range(0, moles.Count);
        Mole tempMole = moles[rand];
        if(lastHit == tempMole)
        {
            return;
        }
        moles.Remove(tempMole);
        tempMole.Open();
        timer = Time.time;
    }
}
