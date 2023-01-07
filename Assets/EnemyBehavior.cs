using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    enum State {
        None,
        Approach,
        Attack
    }
    
    State state = State.None;
    public GameObject target;
    public SpriteRenderer targetSpriteRenderer;
    public bool toggle = false;

    // When attacking the target, the enemy will attack it as long as it's within range distance.
    // When moving towards the target, the enemy will get within approach distance before attacking.
    public float approachDistance = 5.0f;
    public float rangeDistance = 10.0f;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Approach;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = gameObject.transform.position;
        Vector2 positionOfTarget = target.transform.position;
        float distance = Vector2.Distance(position, positionOfTarget);
        if (state == State.Approach) {
            // If target is within approach distance, change to attack state, otherwise, move towards target.
            if (distance < approachDistance) {
                state = State.Attack;
            }
            else {
                MoveTowardsTarget(position, positionOfTarget);
            }
        }
        else if (state == State.Attack) {
            // If target is in range, attack, otherwise change to approach.
            if (distance < rangeDistance) {
                AttackTarget(target);
            }
            else {
                state = State.Approach;
            }
        }
    }

    void MoveTowardsTarget(Vector2 position, Vector2 positionOfTarget)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void AttackTarget(GameObject target)
    {
        if (toggle)
        {
            targetSpriteRenderer.color = Color.red;
        }
        else
        {
            targetSpriteRenderer.color = Color.blue;
        }
        toggle = !toggle;
    }
    

}
