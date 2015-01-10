using UnityEngine;
using System.Collections;

public class Starfield : MonoBehaviour {

	Transform thisTransform;
	ParticleSystem.Particle[] points;

	public int starsMax;
	public float starSize;
	public float starDistance;
	public float starClipDistance;

	float starDistanceSquare;
	float starClipDistanceSquare;

	// Use this for initialization
	void Start () {
		thisTransform = transform;
		starDistanceSquare = starDistance * starDistance;
		starClipDistanceSquare = starClipDistance * starClipDistance;
		CreateStars ();
	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0; i < starsMax; i++)
		{
			points[i].velocity = thisTransform.forward * 5f;
			if((points[i].position - thisTransform.position).sqrMagnitude > starDistanceSquare)
			{
				points[i].position = Random.insideUnitSphere.normalized * starDistance + thisTransform.position;
			}
			if((points[i].position - thisTransform.position).sqrMagnitude <= starClipDistanceSquare)
			{
				float percent = (points[i].position - thisTransform.position).sqrMagnitude / starClipDistanceSquare;
				points[i].color = new Color(1,1,1,percent);
				points[i].size = percent * starSize;
			}

			particleSystem.SetParticles(points, points.Length);
		}
	}

	private void CreateStars()
	{
		points = new ParticleSystem.Particle[starsMax];

		for(int i = 0; i < starsMax; i++)
		{
			points[i].position = Random.insideUnitSphere * starDistance + thisTransform.position;
			points[i].color = new Color(1,1,1,1);
			points[i].size = starSize;
		}
	}
}
