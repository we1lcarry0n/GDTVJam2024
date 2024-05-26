using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayable : Character
{
    
    private void Update()
    {
        if (!GameManager.Instance.isFight)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            animator.SetFloat("speed", horizontalMovement);
        }
        if (isActiveInBattle && Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(EndedTurnRoutine());
        }
    }

    public void CharacterEnteredBattle()
    {
        animator.SetFloat("speed", 0);
        animator.SetBool("isFight", true);
        return;
    }

    private IEnumerator EndedTurnRoutine()
    {
        yield return new WaitForSeconds(.5f);
        EndTurn();
    }
}
