using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] private float life = 3f;
    [SerializeField] private float timer = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }


    }


    public void Update()
    {
        DartLife();
    }


    private void DartLife()
    {
        life -= Time.deltaTime;
        if (life < 0)
        {
            gameObject.SetActive(false);
            life = timer;
        }

    }

}
