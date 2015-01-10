using System;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class HazardGenerator : MonoBehaviour {

	public class structEnemy
	{
		public string name { get; set; }
		public float x { get; set; }
		public float y { get; set; }
		public float z { get; set; }
		public float rotaX { get; set; }
		public float rotaY { get; set; }
		public float rotaZ { get; set; }
		public int trajectory { get; set; }
	}


	Dictionary<int, List<structEnemy>> container;

	void Start ()
	{
		string filename = "Assets/Resources/Levels/test.lvl";
		ReadLevel (filename);
	}

	void Update ()
	{
		if(container.Values.Count != 0)
		{
			if(container.ContainsKey((int)(Time.timeSinceLevelLoad)))
			{
				foreach(structEnemy s in container[(int)(Time.timeSinceLevelLoad)])
				{
					Instantiate(Resources.Load("Prefabs/Hazards/" + s.name, typeof(GameObject)), new Vector3(s.x, s.y, s.z), new Quaternion(s.rotaX,s.rotaY,s.rotaZ,0));
				}

				container.Remove((int)(Time.timeSinceLevelLoad));
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
				element.x = float.Parse (enemy[1]);
				element.y = float.Parse (enemy[2]);
				element.z = float.Parse (enemy[3]);
				element.rotaX = float.Parse (enemy[4]);
				element.rotaY = float.Parse (enemy[5]);
				element.rotaZ = float.Parse (enemy[6]);
				element.trajectory = int.Parse (enemy[7]);

				list.Add(element);
				break;
			}
		}
	}
}