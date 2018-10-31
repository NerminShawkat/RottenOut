using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        StartCoroutine(ReturnObjectToPool(collision.gameObject));
    }

    IEnumerator ReturnObjectToPool(GameObject obj)
    {
        yield return new WaitForSeconds(Basket.returnToPoolWaitTime);
        ObstaclePooling.instance.ReturnToPool(obj.tag, obj);
    }
    

}
