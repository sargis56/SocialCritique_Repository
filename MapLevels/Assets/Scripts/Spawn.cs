using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {
	public float nextFire = 0.4f;
    public int numSpawn = 9;
	private float myTime = 0.2f;
	int x= 0;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		myTime = myTime + Time.deltaTime;
        if (numSpawn > 10)
		if (myTime > nextFire)
		{

				var evil = (GameObject)Instantiate(enemy, this.transform.position + new Vector3(0, 0, 0.5f), this.transform.rotation);
                NetworkServer.Spawn(evil);
                myTime = 0.0f;
                numSpawn =+ 1;

		}
	}
}
