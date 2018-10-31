using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField]
    private List<string> _acceptedTag;
    public const float returnToPoolWaitTime = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (_acceptedTag.Contains(other.gameObject.tag))
        {
            StartCoroutine(ReturnObjectToPool(other.gameObject));
        }
    }

    IEnumerator ReturnObjectToPool(GameObject obj)
    {
        yield return new WaitForSeconds(returnToPoolWaitTime);
        ObstaclePooling.instance.ReturnToPool(obj.tag, obj);
    }

}
