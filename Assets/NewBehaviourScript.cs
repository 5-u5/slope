using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject target;
    public Vector3 angle;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        if (Fall.check() == 0) transform.position = target.transform.position + offset;
        transform.LookAt(target.transform.position + angle);
    }
}
