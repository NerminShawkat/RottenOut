using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class _HandIsCLosed : MonoBehaviour {
	public Hand RealHand {
		set;
		private get;
	}
	void Start () {

		this.gameObject.SetActive (false);

	}
    public float angle;
    public Vector3 direction, relative,UnProjectedShit;
    [Range(0,1)]
    public float speed;
    public void UpdateNow()
    {
        if (RealHand)
        {
            var parent = RealHand.transform.parent;
            direction = -Vector3.ProjectOnPlane(RealHand.transform.position - this.transform.position, this.transform.parent.up);

            relative = transform.parent.InverseTransformDirection(direction);

            var forwardOnZ = Vector3.Dot(this.transform.up, -Vector3.forward);
            var zDirection = Mathf.Sign(forwardOnZ);

            angle = Mathf.Atan2(relative.z, relative.x) * 180 / Mathf.PI;
            currentAngle = Mathf.LerpAngle(currentAngle, angle, speed);
            this.transform.localEulerAngles = new Vector3(0, -angle, 0);
        }
    }
    public float currentAngle;
    public void Update () {

		if (RealHand) {
            direction = -Vector3.ProjectOnPlane(RealHand.transform.position-this.transform.position,this.transform.parent.up);

            relative= transform.parent.InverseTransformDirection(direction);



            angle = Mathf.Atan2(relative.z, relative.x) *180/Mathf.PI;
            currentAngle = Mathf.LerpAngle(currentAngle, angle, speed);
            this.transform.localEulerAngles = new Vector3(0, -currentAngle, 0);
		} 
	}
}