using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

	Rigidbody rigid;

	public GameObject bottomRight;
	public GameObject bottomLeft;
	public GameObject topRight;
	public GameObject topLeft;

	public float speed = 10.0f;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addForce(string pos, float force){

		Vector3 posisition = new Vector3();
		Vector3 direction = Vector3.up;
		switch (pos) {
		case "topRight":
			posisition = topRight.transform.position;
			direction = -transform.up;
			break;
		case "topLeft":
			posisition = topLeft.transform.position;
			direction = -transform.up;
			break;
		case "bottomRight":
			posisition = bottomRight.transform.position;
			direction = transform.up;
			break;
		case "bottomLeft":
			posisition = bottomLeft.transform.position;
			direction = transform.up;
			break;

		default:
			break;
		}

		if (posisition != null) {
			rigid.AddForceAtPosition (direction * speed * force, posisition);
		}
	}

	public void addForce(string pos){
		addForce (pos, 1.0f);
	}
}
