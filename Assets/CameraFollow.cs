using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject toFollow;
	public float speed = 2;
	public float step = 10f;
	public float toMoveScale = 0.40f;
	public float magMultiplier = 3f;
	Vector3 pos;

	Rigidbody rigid;
	GameObject player;
	public GameObject parent;
	float velMag = 0f;
	void Start(){
		player = GameObject.FindWithTag ("Player");
		rigid = player.GetComponent<Rigidbody>();
		if (parent == null) {
			parent = GetComponentInParent<GameObject> ();
		}
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, transform.position.z);	
		//(0.5,0.5,10) i midten
		//pos = Camera.main.WorldToViewportPoint (toFollow.transform.position);
		//if ((pos.x < toMoveScale || pos.x > 1 - toMoveScale) || (pos.y < toMoveScale || pos.y > 1 - toMoveScale)) {
		//	Vector3 delta = pos - center;
		//	float mag = delta.magnitude * magMultiplier;
			//parent.transform.position += delta * rigid.velocity.magnitude;
		//	parent.transform.position += delta * (speed * mag * Time.deltaTime);
		//}
		velMag = rigid.velocity.magnitude;
		//transform.position = new Vector3(rigid.velocity.x, rigid.velocity.y, transform.position.z);


		Vector3 pv = parent.transform.position;
		Vector3 plv = toFollow.transform.position;
		
		Vector3 delta2 = plv - pv;
		Vector3 cameraVec = new Vector3 (delta2.x * Time.deltaTime, delta2.y * Time.deltaTime, transform.position.z);
		Vector3 localPos = transform.localPosition;
		float z = localPos.z;
		if (velMag > 2f) {
			localPos = Vector3.MoveTowards (transform.localPosition, rigid.velocity.normalized *(2 * delta2.magnitude), step * Time.deltaTime);
//			if (!AproximateEqual(localPos, (40*delta2))) {
//				Debug.Log (delta2);
//				Vector3 dir = (delta2 - localPos).normalized;
//				dir *= Time.deltaTime * speed * 4;
//				dir.z = 0;
//				transform.localPosition += dir;
//			}
		} else {
			localPos = Vector3.MoveTowards (transform.localPosition, new Vector3(0,0,0), 1.5*step * Time.deltaTime);
		
//			if (!AproximateEqual( localPos, new Vector3(0,0,0))) {
//			Vector3 delta = -localPos;
//			Vector3 newPos = delta * Time.deltaTime;
//			transform.localPosition = new Vector3(newPos.x + localPos.x, newPos.y + localPos.y, localPos.z);
		}
		//TODO: FIX MAGIC NUMGERS
		localPos.z = z;
		transform.localPosition = localPos;
		//transform.localPosition = new Vector3(delta2.x,  delta2.y, transform.position.z);
		if ( !(AproximateEqual(plv,pv))) {
			// hvis spiller ikke er lig boks position
			float mag = delta2.magnitude * delta2.magnitude * magMultiplier;
			parent.transform.position += delta2.normalized * (speed * Time.deltaTime * mag/16);
		}

	}
	bool AproximateEqual(Vector3 a, Vector3 b){
		// is a equals to b with to moveScale as bounds
		return ((a.x - toMoveScale <= b.x && b.x <= a.x + toMoveScale) &&
				(a.y - toMoveScale <= b.y && b.y <= a.y + toMoveScale));
	}

}
