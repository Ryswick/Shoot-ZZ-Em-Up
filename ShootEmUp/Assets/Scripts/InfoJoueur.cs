﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class InfoJoueur{
	
	private static string login;
	private static int IDPlayer;
	private static int IDSkin;
	private static int IDBomb;
	private static List<bool> achievements;
	private static List<double> scores;
	private static float[,] upgradeLevel = new float[5,2];

	public static string GetLogin()
	{
		return login;
	}

	public static int GetIDPlayer()
	{
		return IDPlayer;
	}

	public static int GetIDskin()
	{
		return IDSkin;
	}

	public static int GetIDBomb()
	{
		return IDBomb;
	}

	public static List<bool> GetAchievements()
	{
		return achievements;
	}

	public static bool GetAchievement(int idAchievement)
	{
		return achievements[idAchievement];
	}

	public static List<double> GetScores()
	{
		return scores;
	}

	public static double GetScore(int idLevel)
	{
		return scores[idLevel];
	}

	public static float GetUpgradeLevel(int level, int type)
	{
		float answer = -1;

		if(0 <= level && level < 5 && 0 <= type && type < 2)
			answer = upgradeLevel[level, type];

		return answer;
	}
}
