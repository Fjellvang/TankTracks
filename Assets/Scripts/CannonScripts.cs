using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScripts : MonoBehaviour {
	GameObject cannon; 


	public void Rotate(float angle){
		Debug.Log (angle);
		transform.Rotate(new Vector3(0,0,angle));
	}

	public void RotateAroundZ( float angle, Vector3 point){
		transform.RotateAround (point, new Vector3 (0, 0, 1), angle);
	}
}
