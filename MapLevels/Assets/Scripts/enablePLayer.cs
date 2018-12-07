using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablePLayer : MonoBehaviour {
    public GameObject player;
    public GameObject world;
    public GameObject menu;
    public GameObject spawn;

    // Use this for initialization
    void Start () {
        player.SetActive(true);
        world.SetActive(true);
        menu.SetActive(true);
        spawn.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
