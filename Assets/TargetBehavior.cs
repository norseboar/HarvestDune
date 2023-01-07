using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public bool isHit = false;
    public float speed = 1.0f;
    Vector2 travelDirection = new Vector2(-1, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            Vector2 position2 = gameObject.transform.position;
            gameObject.transform.position = position2 + travelDirection * speed * Time.deltaTime;
        }
        
    }

    void GetHit()
    {
        isHit = true;
    }
}
