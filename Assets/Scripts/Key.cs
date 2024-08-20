using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player.Instance.hasKey = true;
        Destroy(gameObject);
    }

}
