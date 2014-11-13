using UnityEngine;
using System.Collections;

public class AllyProjectile : MonoBehaviour {

	public int speed;
	private float lifetime;
	private int damage;
	
	void OnEnable () {
		rigidbody2D.velocity = Vector3.up * speed;
		lifetime = 1;
		damage = 1;
		Invoke ("Die", lifetime);
	}

	void OnDisable () {
		CancelInvoke("Die");
	}

	void Die()
	{
		Destroy(gameObject);
	}

	public int GetDamage()
	{
		return damage;
	}
}
