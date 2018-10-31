using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField]
    string _acceptedTag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(_acceptedTag))
        {
            Debug.Log("accepted");
        }
    }
}
