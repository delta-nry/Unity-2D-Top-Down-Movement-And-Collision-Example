// Copyright (c) 2017 Nathan Robert Yee

// This code is licensed under the MIT License. Refer to the LICENSE file for
// information regarding the license of this code.

// This code was tested in Unity 5.6.0f3.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Example : MonoBehaviour {
	// These speed variables are meant to be set in the Unity editor.
	public float speedX;
	public float speedY;

	Rigidbody2D rb2D;

	void Start () {
		// Ensure that a BoxCollider2D and Rigidbody2D exist on the
		// GameObject this script is attached to.
		Assert.IsNotNull (GetComponent<BoxCollider2D> ());
		Assert.IsNotNull (GetComponent<Rigidbody2D> ());

		rb2D = GetComponent<Rigidbody2D> ();

		// Set up the Rigidbody2D in case it isn't already
		// set up properly in the Unity editor.
		// The Rigidbody2D should be Dynamic, have a
		// Gravity Scale of 0 and have its Freeze Rotation
		// Constraint set to true.
		rb2D.bodyType = RigidbodyType2D.Dynamic;
		rb2D.gravityScale = 0;
		rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void Update () {
		var nextX = rb2D.transform.position.x;
		var nextY = rb2D.transform.position.y;
		// Get input.
		if (Input.GetKey (KeyCode.W)) {
			nextY += speedY;
		}
		if (Input.GetKey (KeyCode.A)) {
			nextX -= speedX;
		}
		if (Input.GetKey (KeyCode.S)) {
			nextY -= speedY;
		}
		if (Input.GetKey (KeyCode.D)) {
			nextX += speedX;
		}
		// Move the Rigidbody2D.
		rb2D.MovePosition(new Vector2(nextX, nextY));
	}
}
