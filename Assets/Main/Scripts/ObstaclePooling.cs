using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObstaclePooling instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    GameObject objectToSpawn;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
        InvokeRepeating("CheckIfPoolIsOverFlowing", 0, 10);

    }

    //public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Vector3 scale, float returnToPoolCD)
    //{
    //    if (!poolDictionary.ContainsKey(tag))
    //        return null;
    //    if (poolDictionary[tag].Count == 0)
    //    {
    //        for (int i = 0; i < pools.Count; i++)
    //        {
    //            if (pools[i].tag == tag)
    //            {
    //                objectToSpawn = Instantiate(pools[i].prefab);
    //                objectToSpawn.transform.position = position;
    //                objectToSpawn.transform.rotation = rotation;
    //                objectToSpawn.transform.localScale = scale;
    //                StartCoroutine(ReturnToPool(tag, returnToPoolCD, objectToSpawn));
    //                return objectToSpawn;
    //            }
    //            else
    //                return null;
    //        }
    //    }
    //    else
    //    {
    //        objectToSpawn = poolDictionary[tag].Dequeue();

    //        objectToSpawn.SetActive(true);
    //        objectToSpawn.transform.position = position;
    //        objectToSpawn.transform.rotation = rotation;
    //        objectToSpawn.transform.localScale = scale;

    //        StartCoroutine(ReturnToPool(tag, returnToPoolCD, objectToSpawn));
    //        return objectToSpawn;
    //    }
    //    return null;

    //}

    public GameObject SpawnFromPool(string tag, float returnToPoolCD)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;
        if (poolDictionary[tag].Count == 0)
        {
            for (int i = 0; i < pools.Count; i++)
            {
                if (pools[i].tag == tag)
                {
                    objectToSpawn = Instantiate(pools[i].prefab);
                    //StartCoroutine(ReturnToPool(tag, returnToPoolCD, objectToSpawn));
                    return objectToSpawn;
                }
                if (i == pools.Count)
                {
                    return null;
                }
            }
        }
        else
        {
            objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);


            //StartCoroutine(ReturnToPool(tag, returnToPoolCD, objectToSpawn));
            return objectToSpawn;
        }
        return null;

    }

    public void ReturnToPool(string tag/*, float ReturnToPoolTime*/, GameObject returnedObject)
    {
        //yield return new WaitForSeconds(ReturnToPoolTime);
        returnedObject.SetActive(false);
        poolDictionary[tag].Enqueue(returnedObject);
    }

    void CheckIfPoolIsOverFlowing()
    {
        foreach (KeyValuePair<string, Queue<GameObject>> pair in poolDictionary)
        {
            int length = 0;
            for (int i = 0; i < pools.Count; i++)
            {
                if (pair.Key == pools[i].tag)
                {
                    length = pools[i].size;
                    break;
                }
            }
            if (length != 0)
            {
                if (pair.Value.Count > length)
                {
                    while(pair.Value.Count>length)
                    {
                        Destroy(poolDictionary[pair.Key].Dequeue());
                    }
                }
            }
        }
    }
}
