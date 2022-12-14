using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    public Rigidbody rb;
    public GameObject boost;
    public GameObject background;
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
            // Insert deletion code
        }
        if (collider.gameObject.CompareTag("Ramp")) {
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 10f, rb.velocity.z+1000f * Time.deltaTime);
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
                int structure = 0;
                for (int j = 1; j < currentDistance; j ++) {
                    if (currentDistance > 2) structure = Random.Range(3,objects.Length);
                    else structure = Random.Range(0,3);
                    for (int k = 1; k < currentDistance; k ++) {
                        GenerateStructure(structure, trigger);
                    }
                }
                trigger = true;
                GenerateStructure(structure, trigger);
                trigger = false;
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

    public static float[] structs = {90f, 90f, 110f, 110f, 160f, 145f, 60f};
    int genCount = 0;
    public void GenerateStructure(int structure, bool trigger) {
        //currentZ += zStep;
        currentY -= yStep;

        currentZ += structs[structure];
        if (structure == 6) currentY += 10f;
        
        int xRandom = Random.Range(1,15);
        Instantiate(objects[structure], new Vector3(-30f + xRandom, currentY, currentZ), Quaternion.identity);
        if (genCount % 5 == 0) Instantiate(background, new Vector3(150f + xRandom, currentY + 20f, currentZ), Quaternion.identity);
        if (trigger == true) {
            // currentZ += zStep;
            currentZ += 100f;
            currentY -= yStep;
            Instantiate(boost, new Vector3(-30f + xRandom, currentY, currentZ), Quaternion.identity);
        }

        genCount++;
        trigger = false;
    }
}
