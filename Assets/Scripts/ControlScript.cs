using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour {

	CannonScripts cannon;
	public float cannonSpeed = 10f;
	MovementScript move;

	// Use this for initialization
	void Start () {
		cannon = GetComponentInChildren <CannonScripts>();
		move = GetComponentInParent<MovementScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		float input = Input.GetAxis ("Horizontal");
		if (input != 0) {
			input *= -1; // invert it the hacky way
			//cannon.Rotate (cannonSpeed *input * Time.deltaTime);
			cannon.RotateAroundZ(cannonSpeed * input * Time.deltaTime, transform.position);
		}
		float R2 = Input.GetAxis ("R2");
		float L2 = Input.GetAxis ("L2");
		// 7 og 6 er options knapperne
		// 9 er l3 10 er r3
		bool l1button = Input.GetKey(KeyCode.JoystickButton4);
		bool r1button = Input.GetKey(KeyCode.JoystickButton5);
		bool l2button = Input.GetKey(KeyCode.Joystick1Button6);
		bool r2button = Input.GetKey(KeyCode.Joystick1Button7);

		if (l1button) {
			move.addForce ("topLeft",0.5f);
		}
		if (r1button) {
			move.addForce ("topRight",0.5f);
		}
		if (R2 > 0) {
			move.addForce ("bottomRight", R2);
		}
		if (L2 > 0) {
			move.addForce ("bottomLeft", L2);
		}
		Debug.Log(string.Format("R2: {0},{1}, L2: {2},{3}, L1: {4} R1{5}, input: {6}", r2button, R2, l2button, L2, l1button, r1button, input));
	}
}
