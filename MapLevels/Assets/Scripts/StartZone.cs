using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour {

    public GameObject Player;
    public Transform startposition;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("PlayerC");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        Player.transform.position = startposition.transform.position;
    }
}
