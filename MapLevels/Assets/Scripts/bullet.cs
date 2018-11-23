using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed;

    private Rigidbody rBody;
    // Use this for initialization
    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
        rBody.velocity = this.transform.forward * speed;

    }


    private void OnTriggerEnter(Collider other)
    {

		Debug.Log(other.tag);


    }
}
