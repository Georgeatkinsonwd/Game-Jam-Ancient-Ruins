using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DartGun : MonoBehaviour
{
    public Transform dartSpawnPoint;
    [SerializeField] private float speed;
    [SerializeField] private float fireRate;
    private bool isShooting = false;

    void Update()
    {
        StartCoroutine(Shooting());
    }


    private void ShootDart()
    {
        GameObject dart = ObjectPool.instance.GetDartPooledObject();

        if(dart != null)
        {
            dart.transform.position = dartSpawnPoint.position;
            dart.SetActive(true);
        }

        dart.GetComponent<Rigidbody>().velocity = dartSpawnPoint.up * speed;
    }


    IEnumerator Shooting()
    {
        if (isShooting)
        {
            yield break;
        }

        isShooting = true;
        ShootDart();
        yield return new WaitForSeconds(fireRate);
        isShooting = false;
    }
}
