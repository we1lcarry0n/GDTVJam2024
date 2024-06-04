using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPlayable : Character
{
    [SerializeField] private AudioSource stepsAudioSource;
    [SerializeField] private float applyDmgBuffForSkill3;
    [SerializeField] private Skill[] skills;

    [SerializeField] private float skillsDamageMultiplier;

    [SerializeField] private GameObject buffFX;

    [SerializeField] private Sprite[] skillSprites;
    [SerializeField] private string[] characterName;
    [SerializeField] private string[] engSkillDescriptions;
    [SerializeField] private string[] ukrSkillDescriptions;

    [SerializeField] private AudioSource buffAS;

    private float temporarySkillDamageGradeMultiplier;
    public bool isDefeated = false;

    private void Update()
    {
        if (isDefeated && isActiveInBattle)
        {
            Debug.Log($"Character {gameObject.name} is ending turn due to death!");
            EndTurn();
            return;
        }

        if (!GameManager.Instance.isFight && !PlayerManager.Instance.isPressed)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            animator.SetFloat("speed", horizontalMovement);
        }
        if (isActiveInBattle && Input.GetKeyDown(KeyCode.Alpha1))
        {
            isActiveInBattle = false;
            UseSkill1();
            //StartCoroutine(EndedTurnRoutine());
        }
        if (isActiveInBattle && Input.GetKeyDown(KeyCode.Alpha2))
        {
            isActiveInBattle = false;
            UseSkill2();
            //StartCoroutine(EndedTurnRoutine());
        }
        if (isActiveInBattle && Input.GetKeyDown(KeyCode.Alpha3))
        {
            isActiveInBattle = false;
            UseSkill3();
            //StartCoroutine(EndedTurnRoutine());
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
        RemoveTemporaryBuff();
        GetComponent<Health>().DisableAllModifiersOnDamage();
    }

    public override void ActivateCharacterInBattle()
    {
        base.ActivateCharacterInBattle();
        ActivateCharacterOutsidebattle();
    }

    public void DeactivateCharacterOnMouseClickSkill()
    {
        isActiveInBattle = false;
    }

    public void ActivateCharacterOutsidebattle()
    {
        for (int i = 0; i < skillSprites.Length; i++)
        {
            PlayerManager.Instance.playerSkillImages[i].image.sprite = skillSprites[i];
            PlayerManager.Instance.playerSkillImages[i].GetComponent<SkillButton>().SetCurrentActiveCharacter(this);
            if (PlayerPrefs.GetInt("lang") == 0)
            {
                PlayerManager.Instance.playerSkillImages[i].GetComponent<SkillButton>().SetSkillDescription(engSkillDescriptions[i]);
            }
            else
            {
                PlayerManager.Instance.playerSkillImages[i].GetComponent<SkillButton>().SetSkillDescription(ukrSkillDescriptions[i]);
            }
        }
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            PlayerManager.Instance.characterNameText.text = characterName[0];
        }
        else
        {
            PlayerManager.Instance.characterNameText.text = characterName[1];
        }
        PlayerManager.Instance.characterHealthValueText.text = $"{GetComponent<Health>().GetHealthCurrent()} / {GetComponent<Health>().GetHealthMax()}";
    }

    public void UseSkill1()
    {
        List<Transform> targets = new List<Transform>();
        foreach (CharacterEnemy character in EnemyManager.Instance.enemyCharacters)
        {
            targets.Add(character.transform);
        }
        StartCoroutine(skills[0].Init(targets, skillsDamageMultiplier + temporarySkillDamageGradeMultiplier));
        animator.SetTrigger("skill1");
        if (temporarySkillDamageGradeMultiplier != 0)
        {
            RemoveTemporaryBuff();
        }
        StartCoroutine(EndedTurnRoutine());
    }

    public void UseSkill2()
    {
        List<Transform> targets = new List<Transform>();
        foreach (CharacterEnemy character in EnemyManager.Instance.enemyCharacters)
        {
            targets.Add(character.transform);
        }
        StartCoroutine(skills[1].Init(targets, skillsDamageMultiplier + temporarySkillDamageGradeMultiplier));
        animator.SetTrigger("skill2");
        if (temporarySkillDamageGradeMultiplier != 0)
        {
            RemoveTemporaryBuff();
        }
        StartCoroutine(EndedTurnRoutine());
    }

    public void UseSkill3()
    {
        List<Transform> targets = new List<Transform>();
        foreach (CharacterPlayable character in PlayerManager.Instance.playableCharacters)
        {
            targets.Add(character.transform);
            if (applyDmgBuffForSkill3 != 0)
            {
                character.AddTemporaryDmgBuff(applyDmgBuffForSkill3);
            }
        }
        StartCoroutine(skills[2].Init(targets, skillsDamageMultiplier));
        animator.SetTrigger("skill3");
        StartCoroutine(EndedTurnRoutine());
    }

    public void IncreaseDmg(float percentageAmount)
    {
        skillsDamageMultiplier += percentageAmount;
        StartCoroutine(IncreasedDamageFXRoutine());
    }

    public void PlayFootstepSound()
    {
        if (Random.Range(0, 2) == 0)
        {
            return;
        }
        stepsAudioSource.pitch = Random.Range(.9f, 1.1f);
        stepsAudioSource.volume = Random.Range(.8f, 1f);
        stepsAudioSource.Play();
    }

    private void AddTemporaryDmgBuff(float amount)
    {
        buffAS.Play();
        temporarySkillDamageGradeMultiplier = amount;
        buffFX.SetActive(true);
    }

    private void RemoveTemporaryBuff()
    {
        temporarySkillDamageGradeMultiplier = 0;
        buffFX.SetActive(false);
    }

    private IEnumerator EndedTurnRoutine()
    {
        yield return new WaitForSeconds(4.5f);
        EndTurn();
    }

    private IEnumerator IncreasedDamageFXRoutine()
    {
        buffAS.Play();
        buffFX.SetActive(true);
        yield return new WaitForSeconds(1f);
        buffFX.SetActive(false);
    }
}
