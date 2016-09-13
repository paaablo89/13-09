using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefabToPool;
    public int poolSize = 10;
    [HideInInspector]
    public List<GameObject> objectPool = new List<GameObject>();
    public List<GameObject> activePoolObjets = new List<GameObject>();

    void Start()
    {
        if (prefabToPool == null)
        {
            Debug.LogError("PrefabToPool in null. Assing reference in Spector");
        }

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newGamObject = (GameObject)Instantiate(prefabToPool);
            newGamObject.name = "Enemy" + i;
            newGamObject.transform.parent = this.transform;
            objectPool.Add(newGamObject);
            newGamObject.SetActive(false);
        }
    }

    public GameObject SpawnObject()
    {
        if (objectPool.Count <= 0)
        {
            Debug.LogWarning("No more objects pooled t spawn");
            return null;
        }
        int i = objectPool.Count - 1;
        activePoolObjets.Add(objectPool[i]);
        objectPool.RemoveAt(i);
        int j = activePoolObjets.Count - 1;
        activePoolObjets[j].transform.position = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        activePoolObjets[j].SetActive(true);
        return activePoolObjets[j];

    }



}

