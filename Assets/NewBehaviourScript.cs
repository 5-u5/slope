using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject target;
    public float xOffset, yOffset, zOffset;
    // Update is called once per frame
    void Update()
    {
        if (Fall.check() == 0) transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(target.transform.position + new Vector3(0, 3, 0));
    }
}
