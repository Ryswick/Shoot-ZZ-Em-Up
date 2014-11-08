using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;

	void Update ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		Vector2 direction = new Vector2 (x, y).normalized;

		Move (direction);
	}
		
	void Move (Vector2 direction)
	{
		//Screen limits for the player
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		Vector2 pos = transform.position;

		pos += direction  * speed * Time.deltaTime;

		//Ensure that the player will not go out of the screen
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}
}
