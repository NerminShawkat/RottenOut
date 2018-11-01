using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity = new Vector3(0,0,0.1f);
    public Rigidbody rb;
    private VRTK_InteractableObject interactableObject;

    public bool _isOnConveyorBelt;
    public bool _isOnGround;
    public bool _isInBasket;

    void Start ()
    {
        _isOnConveyorBelt = true;
        rb = GetComponent<Rigidbody>();
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, OnGrab);
        interactableObject.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Ungrab, OnUnGrab);
    }
    void OnGrab(object sender, InteractableObjectEventArgs e)
    {
        //velocity = Vector3.zero;
        _isOnConveyorBelt = false;
    }

    void OnUnGrab(object sender, InteractableObjectEventArgs e)
    {
    }
	void Update ()
    {
        if (_isOnConveyorBelt)
        {
            
            rb.velocity = velocity * GameManager.instance.velocityMultiplier;
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }      
        //else
        //{
        //    rb.velocity = Vector3.zero;
        //}
	}
}
