using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ObjectPool objectPool;
    void Start()
    {
        objectPool.CreatePooledObjects();
    }

    
}
