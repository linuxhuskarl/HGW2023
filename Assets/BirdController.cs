using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdController : AnimalController
{
    void FixedUpdate()
    {
        Vector2 target;
        GameObject enemy = FindClosestEnemy();
        if (state == AnimalState.Attack & enemy == null)
        {
            ClearAttack();
        }
        if (state == AnimalState.Attack)
        {
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
                    EnemyController ec = hit.gameObject.GetComponent<EnemyController>();
                    ec.DealDamage(1);
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
        //if (Input.GetButtonDown("Fire1") && state == AnimalState.Idle)
        //{
        //    // TODO usun
        //    Attack();
        //    Invoke(nameof(ClearAttack), 2);
        //}
    }
}
