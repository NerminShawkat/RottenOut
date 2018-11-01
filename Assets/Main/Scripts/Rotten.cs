using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotten : MonoBehaviour {

	
	void Start () {
        GetComponent<Renderer>().materials[0].SetFloat("_RotAmount", Random.Range(0.7f,1));
	}
	
	
}
