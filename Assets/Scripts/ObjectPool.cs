using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int numberOfObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject newObject;
        for (int i = 0; i < numberOfObjects; i++)
        {
            newObject = Instantiate(objectToPool);
            newObject.transform.parent = transform;
            newObject.SetActive(false);
            pooledObjects.Add(newObject);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void DestroyAllObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            pooledObjects[i].SetActive(false);
        }
    }
}
