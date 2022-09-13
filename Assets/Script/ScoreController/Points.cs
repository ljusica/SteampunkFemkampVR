using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    //using TMPtext
    public TMP_Text ScoreText;

    //When "bullets" collide with the thingToShoot add 10 points
    //Add the score to text string
    //Load other scene when points are 30
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "ThingToShoot")
        {
            ScoreKeeper.Score += 10;
            ScoreText.text = (ScoreKeeper.Score).ToString();


            if (ScoreKeeper.Score == 30)
            {
                SceneManager.LoadScene(1);

            }
        }
    }
}


