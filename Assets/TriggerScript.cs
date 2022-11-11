using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    public Rigidbody rb;
    public GameObject boost;
    public int currentDistance = 1;
    public int points = 0;

    public float currentZ = -70f;
    public float currentY = 30f;
    public static float zStep = 120f;
    public static float yStep = 25f;

    public bool trigger = false;

    public void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Point")) {
            points++;
            Text.Update(points);
        }
        if (collider.gameObject.CompareTag("Ramp")) {
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z+300f * Time.deltaTime);
        }
        if (collider.gameObject.CompareTag("Trigger")) {
            if (currentDistance < 2) {
                int structure = Random.Range(0,3);
                for (int j = 1; j < currentDistance; j ++) {
                    GenerateStructure(structure, trigger);
                }
                trigger = true;
                GenerateStructure(structure, trigger);
                trigger = false;

                if (currentDistance < 4) currentDistance++;
                //Debug.Log("Current Distance is " + currentDistance);
            }
            else {
                int structure;
                if (currentDistance > 2) structure = Random.Range(3,objects.Length);
                else structure = Random.Range(0,3);
                for (int x = 1; x <= 3; x++) {
                    for (int j = 1; j < currentDistance; j ++) {
                        GenerateStructure(structure, trigger);
                    }
                    if (x == 3) {
                        trigger = true;
                        GenerateStructure(structure, trigger);
                        trigger = false;
                    }
                }
                if (currentDistance < 4) currentDistance++;
            }
        }
    }
    // Structure 0 is incline
    // Structure 1 is 1 red
    // Structure 2 is left
    // Structure 3 is right
    // Structure 4 is 5 red
    // Structure 5 is 3 red
    // Structure 6 is moving cube

    public static float[] structs = {90f, 90f, 110f, 110f, 160f, 125f, 60f};
    public void GenerateStructure(int structure, bool trigger) {
        //currentZ += zStep;
        currentY -= yStep;

        currentZ += structs[structure];
        
        int xRandom = Random.Range(1,15);
        Instantiate(objects[structure], new Vector3(-30f + xRandom, currentY, currentZ), Quaternion.identity);
        if (trigger == true) {
            // currentZ += zStep;
            currentZ += 100f;
            currentY -= yStep;
            Debug.Log("Generating Trigger");
            Instantiate(boost, new Vector3(-30f + xRandom, currentY, currentZ), Quaternion.identity);
        }

        trigger = false;
    }
}
