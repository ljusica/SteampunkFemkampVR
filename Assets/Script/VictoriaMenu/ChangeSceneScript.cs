using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Drawer bottom")
        {
            SceneManager.LoadScene(1);
            //Debug.Log("Drawer");
        }
    }
}
