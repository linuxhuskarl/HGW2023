using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    enum BirdState
    {
        Idle,
        Attack,
    }

    public float idleSpeed;
    public float attackSpeed;
    public Transform player;
    BirdState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BirdState.Idle;
    }

    private void FixedUpdate()
    {
        Vector2 target = new Vector2(player.position.x-1, player.position.y+1);
        float currentSpeed = GetSpeed(state);
        transform.position = Vector2.MoveTowards(transform.position, target, currentSpeed * Time.fixedDeltaTime);
    }

    private float GetSpeed(BirdState state)
    {
        switch(state)
        {
            case BirdState.Idle:
                return idleSpeed;
            case BirdState.Attack:
                return attackSpeed;
            default:
                return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
