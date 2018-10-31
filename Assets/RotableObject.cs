using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class RotableObject : MonoBehaviour
{
    public bool rotatable;
    public Kandooz.FloatField direction;
    public Kandooz.FloatField wheelReturnSpeed;
    public Transform Wheel;
    public _HandIsCLosed left, right;
    public  GameObject collider;
    private Hand grabbingHand;

    private float lastAngle;
    public float min,max;
    private void Start()
    {
    }
    private void HandHoverUpdate(Hand hand)
    {
        var type = hand.GetGrabStarting(GrabTypes.Grip);
        if (type != GrabTypes.None)
        {
            grabbingHand = hand;
            switch (hand.handType)
            {
                case Valve.VR.SteamVR_Input_Sources.LeftHand:
                    {
                        left.gameObject.SetActive(true);
                        left.RealHand = hand;
                        left.UpdateNow();
                        lastAngle = -Wheel.transform.localRotation.eulerAngles.y + right.transform.localRotation.eulerAngles.y;
                    }
                    break;
                case Valve.VR.SteamVR_Input_Sources.RightHand:
                    {
                        right.gameObject.SetActive(true);
                        right.RealHand = hand;
                        right.UpdateNow();
                        lastAngle = -Wheel.transform.localRotation.eulerAngles.y+right.transform.localRotation.eulerAngles.y;
                    }
                    break;
            }
            //lastAngle = Wheel.transform.localRotation.eulerAngles.y;
            //lastPos = grabbingHand.transform.position;
            hand.SetVisibility (false);
            collider.SetActive(false);
        }

    }

    void Update()
    {
        if (grabbingHand)
        {

            var grabbed = grabbingHand.GetGrabEnding(GrabTypes.Grip);
            if (grabbed != GrabTypes.None)

            {
                switch (grabbingHand.handType)
                {
                    case Valve.VR.SteamVR_Input_Sources.LeftHand:
                        {
                            left.gameObject.SetActive(false);

                        }
                        break;
                    case Valve.VR.SteamVR_Input_Sources.RightHand:
                        {
                            right.gameObject.SetActive(false);
                        }
                        break;
                }
                grabbingHand.SetVisibility(true);
                collider.SetActive(true);
                grabbingHand = null;
                return;

            }
            var hand = grabbingHand.handType == Valve.VR.SteamVR_Input_Sources.LeftHand ? left : right;
            var v1 = hand.transform.localRotation.eulerAngles.y;
            var delta = -this.lastAngle + v1;

            this.lastAngle = v1;
            ////var delta = -Vector3.Angle (v1, v2) * Mathf.Sign (Vector3.Dot (Vector3.Cross (v1, v2), this.transform.up));
            var newAngle = Wheel.transform.localRotation.eulerAngles.y + delta;

            var angle = (newAngle > 180) ? newAngle - 360 : newAngle;

            if (newAngle < max && newAngle > min)
            {
                Wheel.transform.localEulerAngles = new Vector3(
                Wheel.transform.localRotation.eulerAngles.x,
                newAngle,
                Wheel.transform.localRotation.eulerAngles.z);
            }

            
            var value = Mathf.Clamp01((newAngle - min) / (max - min));
            direction.Value = value*2-1;


        }
        else
        {
            //this.transform.RotateAround(transform.position,this.transform.up,Mathf.Sign(angle-180)*Time.deltaTime*wheelReturnSpeed.Value);

        }


    }
}