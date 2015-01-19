using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	public int life;
	public GameObject explosion;
	public int scoreValue;
	bool isDead;
	GameController gameController;
	HazardGenerator generator;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
			generator = gameControllerObject.GetComponent<HazardGenerator>();
		}
		else
		{
			Debug.Log("Cannot find GameController object");
		}
		
		if(gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}

		isDead = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag != "Boundary")
		{
			if(other.tag == "Shoot")
			{
				Damage damageScript = other.GetComponent<Damage>();
				life -= damageScript.getDamage();

				Destroy(other.gameObject);
			}

			// If the object do not have any more life or if there is a frontal contact
			if(!isDead && (life <= 0 || other.tag == "Player" || other.tag == "Hazard"))
			{
				if(other.tag != "Player")
				{
					gameController.AddScore(scoreValue);
					generator.ennemyCount--;
					isDead = true;
				}

				Destruct();
			}
		}
	}

	void Destruct () {
		Instantiate(explosion, transform.position, transform.rotation);

		if(tag == "Player")
		{
			gameController.GameFinished("Defeat");
		}

		Destroy (gameObject);
	}
}