using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnly : MonoBehaviour
{
    public GameObject player;
    float x, y, z;
    Vector3 currentPosition;
    Vector3 secPosition;

    public GameObject p;
    public Transform location;
    private bool toggle;
    // Use this for initialization
    void Start()
    {
        currentPosition = new Vector3(transform.position.x,
                                        0f,
                                        transform.position.z);
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(150, 10, 100, 30), "Spawn"))
        {
            if (!toggle)
            {
                Instantiate(p, location.position, Quaternion.identity);
                toggle = true;

            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "enemy" || other.transform.tag == "bullet")
        {
            
            x = Random.Range(-18, 19);
            z = Random.Range(-15, 10);
            currentPosition = new Vector3(x, 2f, z);
            secPosition = new Vector3(Random.Range(-18, 19), 1f, Random.Range(-15, 10));
            player.transform.position = currentPosition;
            other.transform.position = secPosition;
        }
    }
}
