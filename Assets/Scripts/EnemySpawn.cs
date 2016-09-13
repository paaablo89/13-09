using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public ObjectPool objectPool;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectPool.SpawnObject();
            Debug.Log("hola");
        }
    }
}
