﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Ship {
	
	private int nbLife;
	private int nbBomb;
	private int shootDamage;
	private float upgradeRatio;
	private Bombe bombe;
	private List<Bonus> bonusList;
	public AllyProjectile projectile;
	private bool isShooting;
	private bool isDead;
	private List<Transform> shootPositions;

	void Start ()
	{
		nbLife = 3;
		nbBomb = 1;
		orbDropped = 0;
		isShooting = false;
		isDead = false;

		bonusList = new List<Bonus>();
		shootPositions = new List<Transform>();

		//Storage of all the canons positions on the ship
		for(int i = 0; i < transform.childCount; i++)
			shootPositions.Add(transform.GetChild(i));

		Live();
	}

	void Update ()
	{
		if(!isDead)
		{
			Move ();

			if(Input.GetKey(KeyCode.Z) && !isShooting)
			{
				isShooting = true;
				StartCoroutine(Shoot(shootSpeed));
			}
			if(Input.GetKeyUp(KeyCode.Z))
				isShooting = false;
		}
	}

	//Allow the player to move on the game screen
	void Move ()
	{
		//Get player entries for movement
		Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		//Put camera coordinates in World Coordinates
		Vector3 wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		//Calculate half size of the player sprite
		Vector2 halfSize = (gameObject.GetComponent<SpriteRenderer>().bounds.size)/2;

		//Screen limits for the player
		Vector2 min = new Vector2(-wrld.x + halfSize.x, -wrld.y + halfSize.y);
		Vector2 max = new Vector2(wrld.x/3, wrld.y - halfSize.y);

		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;

		//Ensure that the player will not go out of the screen
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}

	//Initialize the player data each time he comes back to life
	void Live()
	{
		HP = 1;
		speed = 5;
		
		shootDamage = 1;
		upgradeRatio = 0;

		bonusList.Clear();

		//Put camera coordinates in World Coordinates
		Vector3 wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		//Calculate half size of the player sprite
		float halfxSize = (gameObject.GetComponent<SpriteRenderer>().bounds.size.x)/2;

		gameObject.transform.position = new Vector3(-wrld.x/3 + halfxSize, -wrld.y/2, 0);

		isDead = false;

		gameObject.SetActive(true);
	}

	//Gestion of the player afterlife
	void Die()
	{
		isDead = true;
		isShooting = false;
		nbLife--;
		gameObject.SetActive(false);

		if(nbLife > 0)
			Live ();
		
		// Game Over if nbLife < 0
	}

	IEnumerator Shoot(float shootSpeed)
	{
		while(isShooting)
		{
			//Instantiate a projectile on each canon position
			foreach(Transform t in shootPositions)
				Instantiate(projectile, t.position, new Quaternion());

			yield return new WaitForSeconds(shootSpeed);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy")
		{
			Die ();
		}
	}

	public int getNbLife()
	{
		return nbLife;
	}

	public int getNbBomb()
	{
		return nbBomb;
	}

	public float getUpgradeRatio()
	{
		return upgradeRatio;
	}

	public List<Bonus> getBonusList()
	{
		return bonusList;
	}
}