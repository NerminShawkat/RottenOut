using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGeneration : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private float generationTime = 2;
    [SerializeField]
    private List<string> rottenFruits;
    [SerializeField]
    private List<string> freshFruits;
    [SerializeField]
    [Range(0,100)]
    private float rottenProb;

    void Start ()
    {
        InvokeRepeating("GenerateFruit", 0, generationTime);
	}
	
	public void GenerateFruit()
    {
        float num = Random.Range(0, 100);
        GameObject obj = null;
        if(num < rottenProb)
        {
            obj = ObstaclePooling.instance.SpawnFromPool(rottenFruits[Random.Range(0, rottenFruits.Count)],0);
        }
        else
        {
            obj = ObstaclePooling.instance.SpawnFromPool(freshFruits[Random.Range(0, freshFruits.Count)],0);
        }
        obj.transform.position = startPoint.position;
        //obj.transform.rotation = Quaternion.identity;
    }
}
