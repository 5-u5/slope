using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject[] floor;
    [SerializeField] GameObject[] objects;
    public Rigidbody rb;
    public GameObject boost;
    public GameObject deathTrigger;
    public GameObject background;
    public int currentDistance = 1;
    public int points = 0;

    public float currentZ = -70f;
    public float currentY = 30f;
    public static float yStep = 12.5f;

    public bool trigger = false;

    public void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Point")) {
            points++;
            Text.Update(points);
            // Insert deletion code
        }
        if (collider.gameObject.CompareTag("Ramp")) {
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 10f, rb.velocity.z+1000f * Time.deltaTime);
        }
        if (collider.gameObject.CompareTag("Trigger")) {
            int structure = Random.Range(currentDistance - 1, currentDistance + 2);
            if (currentDistance > 1) {
                for (int j = 1; j <= 3; j ++) {
                    
                    if (j == 1) structure = Random.Range(0, 4);
                    else if (j == 2) structure = 4;
                    else structure = Random.Range(5, 7);
                    if (currentDistance == 2 && j == 3) {
                        break;
                    }
                    for (int k = 1; k <= currentDistance; k ++) {
                        if (structure == 2 || structure == 3) structure = Random.Range(2, 4);
                        GenerateStructure(structure, false);
                    }
                }
            }
            else GenerateStructure(structure, false);
            GenerateStructure(7, true);

            if (currentDistance < 4) currentDistance++;
        }
    }
    /*
      *  Structure 0 is incline
      *  Structure 1 is 1 red
      *  Structure 2 is left
      *  Structure 3 is right
      *  Structure 4 is 5 red
      *  Structure 5 is 3 red
      *  Structure 6 is moving cube
    */

    /*
    Start: 1 incline, 1 red, slant
            (0 - 3)
    Middle: 5 Red, Curved, Square tunnel
            (4 -)
    End: Moving Cube, 3 Red
            (5 - 6)
    */

    int genCount = 0;
    float lastSize = 0f;
    public void GenerateStructure(int structure, bool trigger) {
        float currentSize = floor[structure].GetComponent<Transform>().localScale.z;
        //Debug.Log(currentSize + " " + currentZ);
        // Creates a random number for the structures to generate off center
        int xRandom = Random.Range(1,15);
        /* Generates the background */
        if (genCount % 5 == 0) Instantiate(background, new Vector3(150f, currentY + 20f, currentZ), Quaternion.identity);
        /* Generates the structures */
        currentY -= yStep;
        currentZ += (currentSize / 2) + (lastSize / 2) + 5f;
        if (structure == 2 || structure == 3) currentY += 5;
        if (trigger == true) {
            Instantiate(boost, new Vector3(-30f, currentY - 3f, currentZ), Quaternion.identity);
        }
        else {
            Instantiate(objects[structure], new Vector3(-30f + xRandom, currentY, currentZ), Quaternion.identity);
        }
        Instantiate(deathTrigger, new Vector3(-30f, currentY - 70f, currentZ), Quaternion.identity);
        
        Debug.Log(currentZ);
        lastSize = currentSize;
        genCount++;
    }
}
