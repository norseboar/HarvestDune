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
    public TargetBehavior target;

    // When attacking the target, the enemy will attack it as long as it's within range distance.
    // When moving towards the target, the enemy will get within approach distance before attacking.
    // TODO: It would be cool if it observed the direction the target is moving,
    //  and only got within approach distance if it saw that it was moving away from the enemy.
    public float approachDistance = 5.0f;
    public float rangeDistance = 10.0f;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Approach;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        Vector2 positionOfTarget = target.transform.position;
        float distance = Vector2.Distance(position, positionOfTarget);
        if (state == State.Approach) {
            // If target is within approach distance, change to attack state, otherwise, move towards target.
            if (distance < approachDistance) {
                state = State.Attack;
            }
            else {
                transform.position = Vector2.MoveTowards(position, positionOfTarget, speed * Time.fixedDeltaTime);
            }
        }
        else if (state == State.Attack) {
            // If target is in range, attack, otherwise change to approach.
            if (distance < rangeDistance) {
                target.TriggerHit(gameObject);
            }
            else {
                state = State.Approach;
            }
        }
    }

}
