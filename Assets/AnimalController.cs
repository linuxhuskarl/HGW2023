using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackAudioClip;
    public float audioVolume = 1f;
    internal AnimalState state;
    internal enum AnimalState
    {
        Idle,
        Attack,
    }

    public float idleSpeed;
    public float attackSpeed;
    public Transform player;
    internal BoxCollider2D col2d;
    // Start is called before the first frame update
    void Start()
    {
        col2d = GetComponent<BoxCollider2D>();
        state = AnimalState.Idle;
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    public void Attack()
    {
        state = AnimalState.Attack;
        audioSource?.PlayOneShot(attackAudioClip, audioVolume);
    }
    public void ClearAttack()
    {
        state = AnimalState.Idle;
    }

}
