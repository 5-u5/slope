using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public GameObject target;
    public bool x = false;
    public float speed;
    public float playerSpeed;
    Rigidbody rb;
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Boost")) {
            Boost();
        }
    }
    void Update()
    {
        Rigidbody rb = target.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z+playerSpeed * Time.deltaTime);
    }
    public void Boost() {
        Rigidbody rb = target.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z+speed * Time.deltaTime);
    }
}
