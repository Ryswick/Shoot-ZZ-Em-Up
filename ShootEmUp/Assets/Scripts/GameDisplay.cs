using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameDisplay : MonoBehaviour {
	
	private long highscore;
	private long score;
	private long scoreDisplayed;
	private List<GameObject> lifeDisplayed;
	private List<GameObject> bombDisplayed;
	private float upgradeRatio;
	private List<Bonus> bonusList;
	private List<Text> textList;
	private Player player;

	private Sprite lifeTexture;
	private Sprite bombTexture;

	// Use this for initialization
	void Start () {
		textList = new List<Text>();

		for(int i = 0; i < 6; i++)
			textList.Add(transform.GetChild(i).GetComponent<Text>());

		highscore = InfoJoueur.GetScore(InfoJoueur.GetActualLevel());

		textList[0].text = "Highscore " + highscore;

		score = 0;
		scoreDisplayed = 0;

		player = GameObject.Find("Player").GetComponent<Player>();

		upgradeRatio = player.getUpgradeRatio();
		bonusList = player.getBonusList();

		lifeTexture = (Sprite)Resources.Load("Heart", typeof(Sprite));

		/*for(int i = 0; i < player.getNbLife(); i++)
		{
			lifeDisplayed.Add(new GameObject());
			lifeDisplayed[i].transform.position = new Vector3(0, i, 0);
			lifeDisplayed[i].AddComponent("SpriteRenderer");
			lifeDisplayed[i].GetComponent<SpriteRenderer>().sprite = lifeTexture;
			lifeDisplayed[i].SetActive(true);
			Instantiate(lifeDisplayed[i]);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if(score!=scoreDisplayed)
		{
			textList[1].text = "Score " + score;
			scoreDisplayed = score;
		}
		if(score > highscore)
		{
			textList[0].text = "Highscore " + score;
			highscore = score;
		}
		//Affichage vie
		//Affichage bombs
		//Affichage ratio
		//Affichage bonus
	}

	public void addPoint(int points)
	{
		score += points;
	}
}
