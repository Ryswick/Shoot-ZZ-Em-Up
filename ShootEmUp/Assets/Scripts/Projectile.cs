using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int speed;
	private float lifetime;
	private int damage;
	
	void OnEnable () {
		rigidbody2D.velocity = Vector3.up * speed;
		lifetime = 1;
		Invoke ("Die", lifetime);
	}

	void OnDisable () {
		CancelInvoke("Die");
	}

	void Die()
	{
		DestroyImmediate(gameObject);
	}

	public int GetDamage()
	{
		return damage;
	}
}
