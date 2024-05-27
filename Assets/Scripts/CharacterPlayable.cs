using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayable : Character
{
    [SerializeField] private Skill[] skills;

    [SerializeField] private float skillsDamageMultiplier;

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
            UseSkill1();
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

    public void UseSkill1()
    {
        List<Transform> targets = new List<Transform>();
        foreach (CharacterEnemy character in EnemyManager.Instance.enemyCharacters)
        {
            targets.Add(character.transform);
        }
        skills[0].Init(targets, skillsDamageMultiplier);
        //animator.SetTrigger("skill1");
    }

    private IEnumerator EndedTurnRoutine()
    {
        yield return new WaitForSeconds(.5f);
        EndTurn();
    }
}
