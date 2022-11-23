using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    public static bool dead = false;
    public Camera cam;
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Fall")) death();
    }
    public void death() {
        dead = true;
        Invoke(nameof(ReloadLevel), 3.3f);
    }
    void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        dead = false;
    }
    public static int check() {
        if (dead == true) return 1;
        else return 0;
    }
}
