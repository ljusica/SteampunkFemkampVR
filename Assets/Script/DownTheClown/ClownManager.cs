using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownManager : MonoBehaviour
{
    public List<GameObject> row1, row2, row3;

    private int rowDown = 0;

    void Start()
    {
        row1 = new List<GameObject>();
        row2 = new List<GameObject>();
        row3 = new List<GameObject>();
        ClownKnockEvent.knockDown += KnockDown;
    }

    public void KnockDown(GameObject clown)
    {
        Clown clownRef = clown.transform.GetComponentInChildren<Clown>();
        switch (clownRef.row)
        {
            case 1:
                row1.Add(clown);
                break;

            case 2:
                row2.Add(clown);
                break;

            case 3:
                row3.Add(clown);
                break;
        }

        if(row1.Count == 3 && rowDown != 1)
        {
            CheckRowDown();
            rowDown = 1;
        }
        else if(row2.Count == 4 && rowDown != 2)
        {
            CheckRowDown();
            rowDown = 2;
        }
        else if(row3.Count == 5 && rowDown != 3)
        {
            CheckRowDown();
            rowDown = 3;
        }

        AddScore(clownRef);
    }

    private void AddScore(Clown clown)
    {
        float score = clown.score * clown.multiplier;
        print(score);
        clown.multiplier = 1;
        clown.ChangeColor();
    }

    private void CheckRowDown()
    {
        if(rowDown == 0)
            return;

        if(rowDown == 1)
        {
            foreach(GameObject clown in row1)
            {
                clown.GetComponent<FlipClown>().BackFlip();
                clown.transform.GetComponentInChildren<Clown>().flipped = false;
            }
            row1.Clear();
        }
        else if (rowDown == 2)
        {
            foreach (GameObject clown in row2)
            {
                clown.GetComponent<FlipClown>().BackFlip();
                clown.transform.GetComponentInChildren<Clown>().flipped = false;
            }
            row2.Clear();
        }
        else if (rowDown == 3)
        {
            foreach (GameObject clown in row3)
            {
                clown.GetComponent<FlipClown>().BackFlip();
                clown.transform.GetComponentInChildren<Clown>().flipped = false;
            }
            row3.Clear();
        }
    }

    private void OnDestroy()
    {
        ClownKnockEvent.knockDown -= KnockDown;
    }
}
