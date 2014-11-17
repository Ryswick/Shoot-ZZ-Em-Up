using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public int HP;
	public float speed;
	public float shootSpeed;
	public int score;
	protected Sprite skin;
	public int orbDropped;
	private bool holdBonus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(HP<=0)
			Die();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "AllyProjectile")
		{
			AllyProjectile pa = coll.gameObject.GetComponent<AllyProjectile>();
			HP -= pa.GetDamage();
			coll.gameObject.SendMessage("Die");
		}
	}

	void Die()
	{
		GameObject.Find("Canvas").GetComponent<GameDisplay>().addPoint(score);
		Destroy(gameObject);
	}
}
