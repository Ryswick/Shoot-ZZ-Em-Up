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

		lifeTexture = (Sprite)Resources.Load("Sprites/Heart", typeof(Sprite));

		lifeDisplayed = new List<GameObject>();
		bombDisplayed = new List<GameObject>();
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
		if(lifeDisplayed.Count != player.getNbLife())
		{
			LifeDisplay();
		}

		//Affichage bombs

		if(upgradeRatio != player.getUpgradeRatio())
		{
			textList[4].text = "Upgrade " + upgradeRatio + " / 4.00";
		}

		//Affichage bonus

	}

	void LifeDisplay()
	{
		if(lifeDisplayed.Count < player.getNbLife())
		{
			for(int i = lifeDisplayed.Count; i < player.getNbLife(); i++)
			{
				lifeDisplayed.Add((GameObject)Instantiate(new GameObject(), new Vector3(4.5f+(i/3f), 1.43f, 0), new Quaternion()));
				lifeDisplayed[i].AddComponent("SpriteRenderer");
				lifeDisplayed[i].GetComponent<SpriteRenderer>().sprite = lifeTexture;
			}
		}
		else
		{
			for(int i = lifeDisplayed.Count-1; i >= player.getNbLife();i--)
			{
				Destroy(lifeDisplayed[i]);
				lifeDisplayed.RemoveAt(i);
			}
		}
	}

	public void addPoint(int points)
	{
		score += points;
	}
}
