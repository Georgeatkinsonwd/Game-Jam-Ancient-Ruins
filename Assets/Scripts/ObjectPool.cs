using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> dartPooledObjects = new List<GameObject>();
    private int dartsToPool = 40;
    [SerializeField] private GameObject dartPrefab;

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetDartPooledObject() { 

        for (int i = 0; i < dartPooledObjects.Count; i++)
        {
            if (!dartPooledObjects[i].activeInHierarchy)
            {
                return dartPooledObjects[i];
            }
        }
        return null;
    }


    public void CreatePooledObjects()
    {
        for(int i = 0; i< dartsToPool; i++)
        {
            GameObject dart = Instantiate(dartPrefab, transform);
            dart.SetActive(false);
            dartPooledObjects.Add(dart);
        }
    }
}
