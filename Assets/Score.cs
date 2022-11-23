using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static TextMeshProUGUI text;
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(g);
    }
    public static void Update(int score) {
        text.text = score.ToString();
    }
    // Update is called once per frame
}
