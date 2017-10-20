﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour {


	//My Variables
	[SerializeField]
	private float topY;
	[SerializeField]
	private float bottomY;
	[SerializeField]
	private float leftX;
	[SerializeField]
	private float rightX;

	private Transform _transform;
	private Vector2 _currentPos;
	private float speed;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	//Set the Speed and allow object to move.
	void FixedUpdate () {
		speed = 0.35f;
		_currentPos = _transform.position;
		//This allows smoother movement when going backwards
		if (Input.GetKey (KeyCode.A)) {
			speed = 0.6f;
			_currentPos -= new Vector2 (speed, 0);
		}
		
		if(Input.GetKey(KeyCode.D))
			_currentPos += new Vector2 (speed,0);
		
		if(Input.GetKey(KeyCode.W))
			_currentPos += new Vector2 (0,speed);
		
		if(Input.GetKey(KeyCode.S))
			_currentPos -= new Vector2 (0,speed);

		boundaryCheck ();
		_transform.position = _currentPos;
	}

	//Check for bounadies and stop UFO from moving out of camera views
	private void boundaryCheck(){

		if (_currentPos.x < leftX)
			_currentPos.x = leftX;

		if (_currentPos.x > rightX)
			_currentPos.x = rightX;

		if (_currentPos.y > topY)
			_currentPos.y = topY;

		if (_currentPos.y < bottomY)
			_currentPos.y = bottomY;



	}


}