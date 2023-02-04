using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : AnimalController
{
    public float idleSpeed;
    public float attackSpeed;
    public Transform player;
    private BoxCollider2D col2d;
    // Start is called before the first frame update
    void Start()
    {
        col2d = GetComponent<BoxCollider2D>();
        state = AnimalState.Idle;
    }

    void FixedUpdate()
    {
        Vector2 target;
        if (state == AnimalState.Attack)
        {
            GameObject enemy = FindClosestEnemy();
            target = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
        }
        else
        {
            target = new Vector2(player.position.x - 1, player.position.y + 1);
        }
        float currentSpeed = GetSpeed(state);
        transform.position = Vector2.MoveTowards(transform.position, target, currentSpeed * Time.fixedDeltaTime);

        if (state == AnimalState.Attack)
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, col2d.size, 0);
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    CancelInvoke(nameof(ClearAttack));
                    ClearAttack();
                    break;
                }
            }
        }
    }

    private float GetSpeed(AnimalState state)
    {
        return state switch
        {
            AnimalState.Idle => idleSpeed,
            AnimalState.Attack => attackSpeed,
            _ => 0,
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && state == AnimalState.Idle)
        {
            // TODO usun
            Attack();
            Invoke(nameof(ClearAttack), 2);
        }
    }
}
