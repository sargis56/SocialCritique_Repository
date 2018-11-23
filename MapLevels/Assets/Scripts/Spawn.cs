using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public float nextFire = 0.4f;
	private float myTime = 0.2f;

	public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		myTime = myTime + Time.deltaTime;

		if (myTime > nextFire)
		{

			Instantiate(enemy, this.transform.position + new Vector3(0, 0, 0.5f), this.transform.rotation);
			myTime = 0.0f;
		}
	}
}
