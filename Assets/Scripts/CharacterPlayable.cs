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
            isActiveInBattle = false;
            StartCoroutine(EndedTurnRoutine());
        }
    }

    public void CharacterEnteredBattle()
    {
        animator.SetFloat("speed", 0);
        animator.SetBool("isFight", true);
        return;
    }

    public void CharacterExitedBattle()
    {
        animator.SetBool("isFight", false);
    }

    private IEnumerator EndedTurnRoutine()
    {
        EnemyManager.Instance.enemyCharacters[0].GetComponent<Health>().ModifyHealth(-50);
        EnemyManager.Instance.enemyCharacters[1].GetComponent<Health>().ModifyHealth(-40);
        EnemyManager.Instance.enemyCharacters[2].GetComponent<Health>().ModifyHealth(-30);
        yield return new WaitForSeconds(.5f);
        EndTurn();
    }
}
