using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour {

    public GameObject Player;
    public Transform startposition;

    // Use this for initialization
    void Awake()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("PlayerC");
    }

    private void OnTriggerEnter(Collider other)
    {

        Player.transform.position = startposition.transform.position;
    }
}
