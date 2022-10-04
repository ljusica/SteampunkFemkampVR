using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonVR : MonoBehaviour
{
    public GameObject boxes;

    public UnityEvent onCollide;
    public UnityEvent onRelease;
    GameObject presser;

    bool isPressed;

    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider Hands)
    {
        if (!isPressed)
        {
            presser = Hands.gameObject;
            onCollide.Invoke();
            isPressed = true;
            

            //SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            onRelease.Invoke();
            
            isPressed = false;
            Debug.Log("touched");

        }
    }

    /*void OnCollisionEnter(Collision other)
    {
        if (gameObject.tag == "Interactive")
        {
            SceneManager.LoadScene(1);
        }
    }*/

    /*public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();
    }*/
}
