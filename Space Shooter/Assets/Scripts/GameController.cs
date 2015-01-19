using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText scoreText;
	public GUIText highScoreText;
	public GUIText newHighScoreText;
	public GUIText restartText;
	public GUIText quitText;
	public GUIText gameOverText;
	
	bool gameEnded;

	int selectedChoice;

	long score;
	long highScore;

	void Start ()
	{
		gameEnded = false;
		restartText.text = "";
		quitText.text = "";
		gameOverText.text = "";
		newHighScoreText.text = "";
		selectedChoice = 0;
		highScore = InfoJoueur.getHighScore();
		score = 0;
		UpdateScore();
		UpdateHighScore();
	}

	void Update ()
	{
		if(gameEnded)
		{
			if(Input.GetAxisRaw("Vertical") > 0 && selectedChoice != 0)
				selectedChoice --;
			else if (Input.GetAxisRaw("Vertical") < 0 && selectedChoice != 1)
				selectedChoice ++;
			
			if(selectedChoice == 0 && restartText.fontStyle != FontStyle.Bold)
			{
				restartText.fontStyle = FontStyle.Bold;
				quitText.fontStyle = FontStyle.Normal;
			}
			else if (selectedChoice == 1 && quitText.fontStyle != FontStyle.Bold)
			{
				quitText.fontStyle = FontStyle.Bold;
				restartText.fontStyle = FontStyle.Normal;
			}

			if(Input.GetButtonDown("Fire1"))
			{
				switch(selectedChoice)
				{
				case 0 : 
					Application.LoadLevel(Application.loadedLevel);
					break;
				case 1 : 
					//Application.LoadLevel(MainMenu);
					break;
				}
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
		if(score > highScore)
		{
			highScore = score;
			UpdateHighScore();
		}
	}

	void UpdateHighScore ()
	{
		highScoreText.text = "HighScore: " + highScore;
    }

	public void GameFinished (string endText)
	{
		gameEnded = true;

		gameOverText.text = endText;

		if(InfoJoueur.updateHighScore(score))
		{
			newHighScoreText.text = "New HighScore !";
		}

		restartText.text = "Restart";
		quitText.text = "Main Menu";
	}

	public bool isGameEnded()
	{
		return gameEnded;
	}
}
