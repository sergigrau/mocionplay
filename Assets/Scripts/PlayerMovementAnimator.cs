using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimator : MonoBehaviour
{

    [SerializeField] public Animator animator;
    [SerializeField] public PlayerMotion motion;

    [SerializeField] private string idleName;
    [SerializeField] private string movementName;
    [SerializeField] 

    private float magnitude;
    // Update is called once per frame
    void FixedUpdate()
    {
        magnitude = motion._input.magnitude;

        if (!motion.iswall)
        {
            if (motion.canMove)
            {
                if (magnitude == 0)
                {
                    animator.Play("Idle", 0, 0.5f);
                    animator.speed = 0.5f;
                }
                else
                {
                    animator.SetFloat(movementName, 1f + ((magnitude * magnitude) * 1.5f));
                    animator.speed = 0.5f + (magnitude * 0.6f);

                }

            }
        }
        else
        {
            animator.Play("Idle", 0, 0.5f);
            animator.speed = 0.5f;
        }
    }
}
