using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        MovementScript ms = collision.gameObject.GetComponent<MovementScript>();
        if(ms)
        {
            ms._isOnConveyorBelt = true;
            ms._isOnGround = false;
            ms._isInBasket = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        MovementScript ms = collision.gameObject.GetComponent<MovementScript>();
        if (ms)
        {
            ms._isOnConveyorBelt = false;
            ms._isOnGround = false;
            ms._isInBasket = false;
        }
    }
}
