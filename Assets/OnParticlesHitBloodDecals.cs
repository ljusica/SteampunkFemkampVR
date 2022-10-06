using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OnParticlesHitBloodDecals : MonoBehaviour
{
    public GameObject bloodDecal;
    public List<Material> bloodMaterials;
    bool bloodSplattered = false;

    IEnumerator SpawnBloodDecal(GameObject particleSys)
    {
        bloodSplattered = true;
        GameObject decal = Instantiate(bloodDecal);
        decal.transform.position = particleSys.GetComponent<ParticleCollisionEvent>().intersection;
        decal.transform.parent = transform;
        decal.GetComponent<DecalProjector>().material = bloodMaterials[Random.Range(0, bloodMaterials.Count)];
        yield return new WaitForSeconds(0.5f);
        bloodSplattered = false;
    }

    private void OnParticleCollision(GameObject particleSys)
    {
        Debug.Log("Particle hit");
        if (!bloodSplattered)
        {
            StartCoroutine(SpawnBloodDecal(particleSys));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Particle hit2");

    }
}
