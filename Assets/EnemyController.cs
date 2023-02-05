using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Attack,
        Defend,
    }
    public EnemyState state;
    private GameObject player;
    private PlayerController playerController;
    // Start is called before the first frame update
    public int healthPoints = 3;
    public float hitRange = 3f;
    public float hitDelay = 3f;
    public float detectionRange = 10f;
    public float attackSpeed = 0.5f;
    public void DealDamage(int hp=1)
    {
        healthPoints-= hp;
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player").First();
        playerController = player.GetComponent<PlayerController>();
    }
    private float timeSinceLastAttack = 0f;
    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastAttack += Time.fixedDeltaTime;
        Vector3 difference = player.transform.position - transform.position;
        float distance = difference.magnitude;
        if (distance > 1 && distance < 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, attackSpeed * Time.fixedDeltaTime);
        }
        if (distance < hitRange && timeSinceLastAttack > hitDelay)
        {
            // attack
            playerController.DealDamage(1);
            timeSinceLastAttack = 0f;
        }
    }
}
