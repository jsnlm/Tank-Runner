using UnityEngine;
using System.Collections;

public class Obstacle_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Weopon") {
			Destroy(other.gameObject);
			Destroy (gameObject);
		}
	}
}
