using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public bool isHit = false;
    public float speed = 1.0f;
    Vector2 travelDirection = new Vector2(-1, -1);
    
    public bool toggle = false;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
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

    public void TriggerHit(GameObject target)
    {
        GetHit();
        if (toggle)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.blue;
        }
        toggle = !toggle;
    }

    void GetHit()
    {
        isHit = true;
    }
}
