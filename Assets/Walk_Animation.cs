using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Walk_Animation : MonoBehaviour
{
    public Animator m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            m_animator.SetFloat("xMove", 1);
            m_animator.SetFloat("yMove", 0);
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                m_animator.SetFloat("xMove", -1);
                m_animator.SetFloat("yMove", 0);
            }
            else
            {
                m_animator.SetFloat("xMove", 0);
                m_animator.SetFloat("yMove", 0);
            }
        }
    }
}
