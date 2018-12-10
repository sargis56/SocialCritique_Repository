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
        var hit = other.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}
