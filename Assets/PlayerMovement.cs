using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    Rigidbody rb;
    Camera c;
    public float playerSpeed;
    public bool collidingWithFloor = false;
    float timer = 0f;
    float i = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        c = cam.GetComponent<Camera>();
        if (Input.GetKey("a")) {
            rb.velocity = new Vector3(rb.velocity.x-70f * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey("d")) {
            rb.velocity = new Vector3(rb.velocity.x+70f * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }
        
        c.fieldOfView = 98 + (rb.velocity.z * .15f);
        if (collidingWithFloor) {
            //rb.velocity += Vector3.Lerp(rb.velocity, rb.velocity.normalized * playerSpeed * 1, Time.deltaTime * 100099f) * 0.01f;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + playerSpeed * Time.deltaTime);
            collidingWithFloor = true;
        }
        timer += Time.deltaTime;
        if (timer > i) {
            i+=20f;
            playerSpeed++;
        }
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Floor")) collidingWithFloor = true;
        else collidingWithFloor = false;
    }
}
