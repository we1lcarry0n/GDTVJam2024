using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerManager.Instance.isFight)
        {
            animator.SetFloat("speed", 0);
            return;
        }
        float horizontalMovement = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", horizontalMovement);
    }
}
