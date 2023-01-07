using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start() { }

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }
}
