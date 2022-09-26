using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Ball")
        {
            source.Stop();
        } 
    }

    public void ToggleMusic()
    {
        if(source.isPlaying)
            source.Stop();
        else
            source.Play();
    }
}
