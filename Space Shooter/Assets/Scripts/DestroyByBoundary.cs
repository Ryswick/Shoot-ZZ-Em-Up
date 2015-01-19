using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	HazardGenerator generator;

	void Start ()
	{
		generator = GameObject.FindWithTag("GameController").GetComponent<HazardGenerator>();
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Hazard")
		{
			generator.ennemyCount--;
		}

		Destroy(other.gameObject);
	}
}
