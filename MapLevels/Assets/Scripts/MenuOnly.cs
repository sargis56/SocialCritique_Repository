using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnly : MonoBehaviour
{
    public GameObject player;
    float x, y, z;
    Vector3 currentPosition;
    Vector3 secPosition;
    // Use this for initialization
    void Start()
    {
        currentPosition = new Vector3(transform.position.x,
                                        0f,
                                        transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "enemy")
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
