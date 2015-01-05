using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	protected int level;

	// Use this for initialization
	void Start () {
		level = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateLevel()
	{
		if(level<3)
			level++;
	}
}
