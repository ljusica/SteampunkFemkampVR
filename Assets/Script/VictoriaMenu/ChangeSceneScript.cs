using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public string gameName;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Drawer bottom")
        {
            SceneManager.LoadScene(gameName);
            //Debug.Log("Drawer");
        }
    }
}
