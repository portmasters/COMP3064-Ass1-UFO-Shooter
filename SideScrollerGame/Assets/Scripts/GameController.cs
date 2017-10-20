﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//my varibles
	[SerializeField]
	Text lifeLb;
	[SerializeField]
	Text scoreLb;
	[SerializeField]
	Text highScoreLb;
	[SerializeField]
	Text gameOverLb;
	[SerializeField]
	Button restartBtn;


	private int score = 0;
	private int life = 5;

	//The get/set of score.
	public int Score{
		get{ return score; }
		set{ 
			score = value; 
			scoreLb.text = "Score: " + score;
			highScoreLb.text = "High Score: " + score;
		}
	}

	//The get/set of Life.
	public int Life{
		get{ return life; }
		set{ 
			life = value; 

			if (life <= 0) {
				death ();
			} else {
				lifeLb.text = "Life: " + life;
			}
		
		}
	}

	//Set certain canvas objects to hidden upon game start
	private void initialize(){
		Score = 0;
		Life = 2;

		//set visibility
		gameOverLb.gameObject.SetActive (false);
		highScoreLb.gameObject.SetActive (false);
		restartBtn.gameObject.SetActive(false);
		lifeLb.gameObject.SetActive(true);
		scoreLb.gameObject.SetActive(true);
	}

	//Set certain canvas objects to hidden upon gameover
	private void death(){
		
		//set visibility
		gameOverLb.gameObject.SetActive (true);
		highScoreLb.gameObject.SetActive (true);
		restartBtn.gameObject.SetActive(true);
		lifeLb.gameObject.SetActive(false);
		scoreLb.gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		initialize ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Button will reload scene
	public void ResetBtnOnClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
