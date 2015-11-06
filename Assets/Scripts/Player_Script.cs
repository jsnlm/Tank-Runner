using System;
using UnityEngine;
using System.Collections;

public class Player_Script : MonoBehaviour {

	public GameObject Weopon;
	public GameObject barrelPivot;

	public float playerSpeed;
	public int lastSingleLR;
	public int lastSingleFB;
	public int currentLR;
	public int currentFB;

	Ray ray;
	RaycastHit hit;
	Vector3 barrelpivotRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit);
		barrelpivotRotation = barrelPivot.transform.rotation.eulerAngles;
		barrelpivotRotation.y = (float)((180/Math.PI)*Math.Atan2(hit.point.x - transform.position.x, hit.point.z - transform.position.z));
		this.transform.GetChild(1).gameObject.transform.rotation = Quaternion.Euler(barrelpivotRotation);

		if (Input.GetMouseButtonDown(0)) {
			print("Pressed left click.");
			GameObject bulletStartPoint = barrelPivot.transform.GetChild(1).gameObject;
			GameObject bullet = Instantiate(Weopon);
			bullet.transform.position = bulletStartPoint.transform.position;
			bullet.transform.rotation = barrelPivot.transform.rotation;

			bullet.GetComponent<Rigidbody>().velocity = Global_Script.eeulervector(bulletStartPoint.transform.rotation.eulerAngles) * Global_Script.weoponBaseSpeed; 

		}

		if (Input.GetKey ("up") && Input.GetKey ("down")) {
			currentFB = -1 * lastSingleFB;
		} else if (Input.GetKey ("up")) {
			currentFB = 1;
			lastSingleFB = 1;
		} else if (Input.GetKey ("down")) {
			currentFB = -1;
			lastSingleFB = -1;
		} else {
			currentFB = 0;
		}

		if (Input.GetKey ("left") && Input.GetKey ("right")) {
			currentLR = -1 * lastSingleLR;
		} else if (Input.GetKey ("right")) {
			currentLR = 1;
			lastSingleLR = 1;
		} else if (Input.GetKey ("left")) {
			currentLR = -1;
			lastSingleLR = -1;
		} else {
			currentLR = 0;
		}

		if ((Math.Abs (currentLR) + Math.Abs (currentFB)) == 2) {
			transform.position += new Vector3 (currentLR, 0, currentFB) * playerSpeed * 0.70710678118f * Time.deltaTime;
		} else {
			transform.position += new Vector3 (currentLR, 0, currentFB) * playerSpeed * Time.deltaTime;
		}



//		if (currentFB == 1  && currentLR == 1){
//			transform.position += Global_Script.forewardRight * Time.deltaTime;
//		}else if (currentFB == 1  && currentLR == 0){
//			transform.position += Vector3.forward * Time.deltaTime;
//		}else if (currentFB == 1  && currentLR == -1){
//			transform.position += Global_Script.forewardLeft * Time.deltaTime;
//		}else if (currentFB == 0  && currentLR == 1){
//			transform.position += Vector3.right * Time.deltaTime;
//		}else if (currentFB == 0  && currentLR == 0){
//			// Do Nothing
//		}else if (currentFB == 0  && currentLR == -1){
//			transform.position += Vector3.left * Time.deltaTime;
//		}else if (currentFB == -1 && currentLR == 1){
//			transform.position += Global_Script.backRight * Time.deltaTime;
//		}else if (currentFB == -1 && currentLR == 0){
//			transform.position += Vector3.back * Time.deltaTime;
//		}else if (currentFB == -1 && currentLR == -1){
//			transform.position += Global_Script.backLeft * Time.deltaTime;
//		}else{
//			print("something wrong happened");
//		}
	}
}