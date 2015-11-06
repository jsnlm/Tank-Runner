using System;
using UnityEngine;
using System.Collections;



public class Global_Script : MonoBehaviour {

	public GameObject Tank;

	public static float weoponBaseSpeed = 13;
	public static Vector3 forewardLeft;
	public static Vector3 forewardRight;
	public static Vector3 backLeft;
	public static Vector3 backRight;
	// Use this for initialization
	void Start () {
		forewardLeft = (Vector3.forward + Vector3.left) * 0.70710678118f;
		forewardRight= (Vector3.forward + Vector3.right) * 0.70710678118f;
		backLeft = (Vector3.back + Vector3.left) * 0.70710678118f;
		backRight = (Vector3.back + Vector3.right) * 0.70710678118f;

		Instantiate (Tank, Vector3.up, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static Vector3 eeulervector(Vector3 euler)
	{
		float elevation = (float)(Math.PI / 180) * (euler.x); //Deg2Rad(euler.x);
		float heading = (float)(Math.PI / 180) * (euler.y); //Deg2Rad(euler.y);
		return new Vector3(
			(float)(Math.Cos(elevation) * Math.Sin(heading)), 
			(float)(Math.Sin(elevation)), 
	        (float)(Math.Cos(elevation) * Math.Cos(heading)));
	}
}
