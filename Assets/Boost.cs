using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public GameObject target;
    public float speed;

    Rigidbody rb;
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Boost")) {
            BoostFunction();
            SpeedText.TempTimerUp();
        }
    }
    public void BoostFunction() {
        Rigidbody rb = target.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z+speed * Time.deltaTime);
    }
}
