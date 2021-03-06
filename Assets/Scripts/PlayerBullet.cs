﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour 
{
	// Refrence the users information.
    public GameObject UserC; 
    User currentUser;

    public float speed;

	// Use this for initialization.
	void Start () 
	{
        currentUser = FindObjectOfType<CurrentUser>().GetComponent<CurrentUser>().currentUser;
    }
	
	// Update is called once per frame.
	void Update () 
	{
		Vector2 position = transform.position;

		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));


		if (transform.position.y > max.y)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// Collision of player bullet with enemy ship.
		if (currentUser.getHard() == 0 && other.tag == "EnemyShipTag" || other.tag == "BossShipTag")
			// Destroy player's bullet.
			Destroy (gameObject); 
	}
}
