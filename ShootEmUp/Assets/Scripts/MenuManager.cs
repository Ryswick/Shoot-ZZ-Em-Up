using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	
	public void StartGame()
	{
		Application.LoadLevel("GameScene");
		Debug.Log ("Coucou");
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
