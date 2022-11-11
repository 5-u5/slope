// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class DeathTrigger : MonoBehaviour
// {
//     public GameObject plr;
//     public MeshRenderer p1;
//     public Rigidbody p2;
//     public PlayerMovement p3;
//     void OnTriggerEnter(Collider collider) {
//         death();
//     }
//     public static void death() {
//         p1 = plr.GetComponent<MeshRenderer>();
//         p2 = plr.GetComponent<Rigidbody>();
//         p3 = plr.GetComponent<PlayerMovement>();
//         p1.enabled = false;
//         p2.isKinematic = true;
//         p3.enabled = false;
//         ReloadLevel();
//     }
//     static void ReloadLevel() {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//     }
// }
