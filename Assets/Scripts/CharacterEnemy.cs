using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnemy : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isFight)
        {
            animator.SetTrigger("IsFight");
        }
    }
}
