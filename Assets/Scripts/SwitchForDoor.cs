using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchForDoor : MonoBehaviour
{
    public GameObject door;


    private void OnTriggerEnter(Collider other)
    {
        door.SetActive(false);
    }


}
