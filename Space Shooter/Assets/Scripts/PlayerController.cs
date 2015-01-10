using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[System.Serializable]
	public class Boundary
	{
		public float xMin, xMax, yMin, yMax;
	}

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public float fireRate;

	private float nextFire;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
			Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
			audio.Play();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal,moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3
		(
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);

		rigidbody.rotation = Quaternion.Euler (rigidbody.velocity.y * -tilt, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
