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
        float input = Input.GetAxisRaw("Horizontal");
        m_animator.SetFloat("xMove", input);
    }
}
