using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text2 : MonoBehaviour
{
    public int points = 0;
    public static TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public static void Update(int point)
    {
        text.text = point.ToString();
    }
}
