using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public bool auto= false;
    public void Start() {
        if (auto == true) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Death() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void Switch() {
        if (auto == false) auto = true;
        else auto = false;
    }
}
