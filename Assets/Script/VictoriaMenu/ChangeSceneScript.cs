using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    /*public GameObject Box0;
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Box4;*/

    void OnCollisionEnter(Collision drawerBottom)
    {
        if (gameObject.tag == "Box0")
        {
            Debug.Log("Collision happened");
        }
    }




    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box0")
        {
            Debug.Log("Triggered");
        }
    }*/
}
