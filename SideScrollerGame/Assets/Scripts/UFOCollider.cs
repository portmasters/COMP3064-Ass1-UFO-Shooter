﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCollider : MonoBehaviour {

	//My Variables
	[SerializeField]
	GameObject death = null;
	[SerializeField]
	GameController gameController;


	private AudioSource deathSound = null;
	private AudioSource coinSound = null;

	void Start (){
		
	}


	void OnTriggerEnter2D(Collider2D external){

		//Coin Collision
		if (external.gameObject.tag == ("PickUp")) {
			Debug.Log ("Coin Collision\n");

			//Reset Object
			external.gameObject.GetComponent <CoinController> ().Reset();

			//set coinSound to the colider object audio source. Play coinSound
			coinSound = external.gameObject.GetComponent<AudioSource>();
			if (coinSound != null) 
				coinSound.Play ();

			//Update Scoreboard
			gameController.Score += 50;

		}
		//Enemy Collision
		else if (external.gameObject.tag == ("Enemy")) {
			Debug.Log ("EyeBall Collision\n");

			//Explode upon collision
			GameObject o = Instantiate (death);
			o.transform.position = external.gameObject.transform.position;

			//Reset Object
			external.gameObject.GetComponent <EyeBallController> ().Reset();

			//Set deathSound to the colider object audio source. Play deathSound
			deathSound = external.gameObject.GetComponent<AudioSource>();
			if (deathSound != null) 
				deathSound.Play ();

			//Upon collision remove a life. Destroy gameobject when life==0 and game music will end as well.
			gameController.Life--;
			if (gameController.Life == 0)
				Destroy (gameObject);
		}



	}


}
