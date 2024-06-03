using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEnemy : Character
{

    [field : SerializeField] public Slider enemyHealthBar { get; private set; }

    [SerializeField] private Skill[] skills;

    [SerializeField] private ParticleSystem spawnFX;
    [SerializeField] private AudioSource spawnAS;

    [SerializeField] private GameObject UICoverGO;

    private void Update()
    {
        if (isActiveInBattle)
        {
            UICoverGO.SetActive(true);
            if (Random.Range(0, 2) == 0)
            {
                UseSkill1();
            }
            else
            {
                UseSkill2();
            }
        }
    }

    public void InitiateFight()
    {
        animator.SetTrigger("IsFight");
        spawnFX.Play();
        spawnAS.Play();
    }

    public void UseSkill1()
    {
        List<Transform> targets = new List<Transform>();
        foreach (CharacterPlayable character in PlayerManager.Instance.playableCharacters)
        {
            targets.Add(character.transform);
        }
        StartCoroutine(skills[0].Init(targets, 1 + 0));
        animator.SetTrigger("skill1");
        StartCoroutine(EndedTurnRoutine());
    }

    public void UseSkill2()
    {
        List<Transform> targets = new List<Transform>();
        foreach (CharacterPlayable character in PlayerManager.Instance.playableCharacters)
        {
            targets.Add(character.transform);
        }
        StartCoroutine(skills[1].Init(targets, 1 + 0));
        animator.SetTrigger("skill2");
        StartCoroutine(EndedTurnRoutine());
    }

    private IEnumerator EndedTurnRoutine()
    {
        isActiveInBattle = false;
        yield return new WaitForSeconds(4f);
        UICoverGO.SetActive(false);
        EndTurn();
    }
}
