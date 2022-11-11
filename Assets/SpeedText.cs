using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static float timer = 0f;
    public static float tempTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > tempTimer) {
            text.text = "";
        }
        else text.text = "SPEED UP";
    }

    public static void TempTimerUp() {
        up();
    }
    static void up() {
        tempTimer = timer + 2f;
    }
}
