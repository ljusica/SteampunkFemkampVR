using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : MonoBehaviour
{
    public int row;
    public bool flipped;
    public float score;
    public float multiplier = 1;

    private float timer;
    private float timeBuffer = 5;

    private void Start()
    {
        timer = Time.time;
    }

    private void Update()
    {
        if(Time.time > timer + timeBuffer)
        {
            int chance = 3 * row;
            int addMultiplier = Random.Range(0, chance);

            if(addMultiplier == 0 && !flipped)
            {
                multiplier = 2;
                ChangeColor();
            }
            else if(addMultiplier != 0 || flipped)
            {
                multiplier = 1;
                ChangeColor();
            }
            timer = Time.time;
        }
    }

    public void ChangeColor()
    {
        Color newColor = new Color();
        if(multiplier == 2)
        {
            newColor = Color.red;
        }
        else if(multiplier == 1)
        {
            newColor = Color.white;
        }

        transform.GetChild(2).GetComponent<MeshRenderer>().material.color = newColor;
    }
}
