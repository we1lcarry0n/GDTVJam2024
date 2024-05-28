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
        if (isActiveInBattle && Input.GetKeyDown(KeyCode.Alpha2))
        {
            isActiveInBattle = false;
            UseSkill2();
            StartCoroutine(EndedTurnRoutine());
        }
        if (isActiveInBattle && Input.GetKeyDown(KeyCode.Alpha3))
        {
            isActiveInBattle = false;
            UseSkill3();
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
        StartCoroutine(skills[0].Init(targets, skillsDamageMultiplier));
        animator.SetTrigger("skill1");
    }

    public void UseSkill2()
    {
        List<Transform> targets = new List<Transform>();
        foreach (CharacterEnemy character in EnemyManager.Instance.enemyCharacters)
        {
            targets.Add(character.transform);
        }
        StartCoroutine(skills[1].Init(targets, skillsDamageMultiplier));
        animator.SetTrigger("skill2");
    }

    public void UseSkill3()
    {
        List<Transform> targets = new List<Transform>();
        foreach (CharacterPlayable character in PlayerManager.Instance.playableCharacters)
        {
            targets.Add(character.transform);
        }
        StartCoroutine(skills[2].Init(targets, skillsDamageMultiplier));
        animator.SetTrigger("skill3");
    }

    private IEnumerator EndedTurnRoutine()
    {
        yield return new WaitForSeconds(2.5f);
        EndTurn();
    }
}
