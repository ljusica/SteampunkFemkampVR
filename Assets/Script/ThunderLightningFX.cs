using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderLightningFX : MonoBehaviour
{
    public bool isThunderActive;

    [SerializeField]
    GameObject thunderLight1;
    [SerializeField]
    GameObject thunderLight2;
    [SerializeField]
    List<AudioClip> thunderSounds = new List<AudioClip>();
    [SerializeField]
    AudioSource thunderAudioSource;
    [SerializeField]
    GameObject player;

    float randomThunderTimer;
    bool willDoSecondThunder;
    void Start()
    {
        if (isThunderActive)
        {
            StartCoroutine(DoThunderFX());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DoThunderFX()
    {
        randomThunderTimer = Random.Range(20f,50f);
        yield return new WaitForSeconds(randomThunderTimer);
        thunderLight1.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        thunderLight1.SetActive(false);
        thunderAudioSource.clip = thunderSounds[Random.Range(0, 3)];
        thunderAudioSource.Play();

        willDoSecondThunder = (Random.Range(1, 3)==1) ? true : false;

        if (willDoSecondThunder)
        {
            randomThunderTimer = Random.Range(3f, 8f);
            yield return new WaitForSeconds(randomThunderTimer);
            thunderLight2.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            thunderLight2.SetActive(false);
            thunderAudioSource.clip = thunderSounds[Random.Range(0, 3)];
            thunderAudioSource.Play();
        }
        StartCoroutine(DoThunderFX());
    }
}
