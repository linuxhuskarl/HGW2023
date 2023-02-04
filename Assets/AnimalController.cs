using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalController : MonoBehaviour
{
    internal AnimalState state;
    internal enum AnimalState
    {
        Idle,
        Attack,
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
    }
    public void ClearAttack()
    {
        state = AnimalState.Idle;
    }

}
