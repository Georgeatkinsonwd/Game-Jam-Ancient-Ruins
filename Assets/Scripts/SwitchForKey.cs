using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchForKey : MonoBehaviour
{
    public GameObject door;


    private void OnTriggerEnter(Collider other)
    {
        if (Player.Instance.hasKey)
        {
            door.SetActive(false);
        }
       
    }

}
