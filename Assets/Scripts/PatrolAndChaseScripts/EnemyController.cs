﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private bool Chase;
    private bool oldChase;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Chase = false;
        oldChase = Chase;
    }

    void Update()
    {
        if (Chase != oldChase)
        {
            if (Chase)
            {
                animator.SetBool("Chase", true);
                oldChase = Chase;

            }
            else if (!Chase)
            {
                animator.SetBool("Chase", false);
                oldChase = Chase;

            }
        }
    }

    public void SetChase(bool chase)
    {
        Chase = chase;
    }
}
