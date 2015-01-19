using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class InfoJoueur{
	
	public static string login;
	public static int IDPlayer;
	public static int IDSkin;
	public static int IDBomb;
	public static List<bool> achievements = new List<bool>();
	public static List<long> scores = new List<long> {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	public static float[,] upgradeLevel = new float[5,2];
	public static int actualLevel = 0;

	public static bool updateHighScore(long score)
	{
		bool newHighScore = false;

		if(score > scores[actualLevel])
		{
			scores[actualLevel] = score;
			newHighScore = true;
		}

		return newHighScore;
	}

	public static long getHighScore()
	{
		return scores[actualLevel];
	}
}
