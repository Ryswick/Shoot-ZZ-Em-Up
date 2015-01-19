using System;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class HazardGenerator : MonoBehaviour {

	public class structEnemy
	{
		public string name;
		public Vector3 position;
		public Vector3 rotation;
		public int trajectory;
		public float speed;
	}


	Dictionary<int, List<structEnemy>> container;

	public int ennemyCount;
	GameController gameController;

	void Start ()
	{
		string filename = "Assets/Resources/Levels/level" + InfoJoueur.actualLevel + ".lvl";
		ennemyCount = 0;
		ReadLevel (filename);
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}

	void Update ()
	{
		if(!gameController.isGameEnded())
		{
			if(container.Values.Count != 0)
			{
				if(container.ContainsKey((int)(Time.timeSinceLevelLoad)))
				{
					foreach(structEnemy s in container[(int)(Time.timeSinceLevelLoad)])
					{
						GameObject g = (GameObject)Resources.Load("Prefabs/Hazards/" + s.name, typeof(GameObject));
						g.GetComponent<HazardMovement>().movementType = s.trajectory;
						g.GetComponent<HazardMovement>().speed = s.speed;

						Instantiate (g, s.position, Quaternion.Euler(s.rotation));
					}

					container.Remove((int)(Time.timeSinceLevelLoad));
				}
			}
			else if(ennemyCount == 0)
			{
				gameController.GameFinished("Victory");
			}
		}
	}

	void ReadLevel (string filename)
	{
		int spawnTime = 0;
		List<structEnemy> list = new List<structEnemy>();
		string[] lines = System.IO.File.ReadAllLines (filename);

		container = new Dictionary<int, List<structEnemy>>();

		foreach (string line in lines)
		{
			switch( line[0] )
			{
			case '+' :
				RenderSettings.skybox = (Material)Resources.Load(line.Trim ('+'), typeof(Material));
				break;
			case '#' :
				spawnTime = int.Parse (line.Trim ('#'));
				break;

			case '_' :
				container.Add(spawnTime, list);
				list = new List<structEnemy>();
				break;

			default :
				string[] enemy = line.Split(' ');
				structEnemy element = new structEnemy();

				element.name = enemy[0];
				element.position = new Vector3(float.Parse (enemy[1]),float.Parse (enemy[2]),float.Parse (enemy[3]));
				element.rotation = new Vector3(float.Parse (enemy[4]),float.Parse (enemy[5]),float.Parse (enemy[6]));
				element.trajectory = int.Parse (enemy[7]);
				element.speed = float.Parse(enemy[8]);

				list.Add(element);
				ennemyCount++;
				break;
			}
		}
	}
}