using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGun : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("ReloadLever"))
        {
            FireGun.canShoot = true;
        }
    }

}
