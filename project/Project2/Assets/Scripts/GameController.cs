﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject explosionPrefab;
	public Text scoreText;
	public Text healthText;
	public Text restartText;
	public GameObject ingameMenu;

	private static GameController _instance;
	private GameObject _explosion;
	private int score = 0;
	private GameObject _deadEnemy;
	private Health playerHealth;

	public static GameController Instance{
		get{
			return _instance;
		}
	}

	// Use this for initialization
	void Awake () {
		if (_instance != null) {
			Debug.LogError( "Duplicate game controller" );
		}

		_instance = this;
	}

	void Start()
	{
		playerHealth = player.GetComponent<Health>( );
		healthText.text = playerHealth.health.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDeath( GameObject go)
	{
		if (go == player) {
			player.SetActive(false);
			Time.timeScale = 0;
			return;
		}

		_explosion = Instantiate (explosionPrefab) as GameObject;
		_explosion.transform.position = go.transform.position;

		score++;
		scoreText.text = score.ToString ();

		if (_deadEnemy != null)
			_deadEnemy.SetActive (true);
		_deadEnemy = go;
		go.SetActive (false);
	}

	void OnDamage( Health health )
	{
		if (health == playerHealth)
			healthText.text = health.health.ToString();
	}

	public void OnPause()
	{
		Time.timeScale = 0;
		ingameMenu.SetActive (true);
	}

	public void OnResume()
	{
		Time.timeScale = 1f;
		ingameMenu.SetActive (false);
	}

	public void OnRestart()
	{
		Application.LoadLevel (0);
		Time.timeScale = 1f;
	}
//	void OnGUI()
//	{
//		GUI.Box (scoreRec, "Kill: " + score);
//
//		GUI.Box (healthRec, "Health: " + playerHealth.health);
//
//		if (!player.activeSelf) {
//			GUI.Box( new Rect(0, 0, Screen.width, Screen.height), "" );
//
//			if( GUI.Button(restartRec, "Restart") )
//			{
//				Time.timeScale = 1f;
//				Application.LoadLevel(0);
//			}
//		}
//	}
}
