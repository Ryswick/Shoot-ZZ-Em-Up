using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;

	void Update ()
	{
		Move ();
	}
		
	void Move ()
	{
		//Get player entries for movement
		Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		//Put camera coordinates in World Coordinates
		Vector2 wrld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

		//Calculate half size of the player sprite
		Vector2 half_size = (gameObject.GetComponent<SpriteRenderer>().bounds.size)/2;

		//Screen limits for the player
		Vector2 min = new Vector2(-wrld.x + half_size.x, -wrld.y + half_size.y);
		Vector2 max = new Vector2(wrld.x/3, wrld.y - half_size.y);

		Vector2 pos = transform.position;

		pos += direction  * speed * Time.deltaTime;

		//Ensure that the player will not go out of the screen
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}
}
