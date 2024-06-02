using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEnemy : Character
{

    [field : SerializeField] public Slider enemyHealthBar { get; private set; }

    [SerializeField] private ParticleSystem spawnFX;
    [SerializeField] private AudioSource spawnAS;

    private void Update()
    {
        if (isActiveInBattle)
        {
            UseSkill();   
        }
    }

    public void InitiateFight()
    {
        animator.SetTrigger("IsFight");
        spawnFX.Play();
        spawnAS.Play();
    }

    private void UseSkill()
    {
        StartCoroutine(UseSkillRoutine());
    }

    private IEnumerator UseSkillRoutine()
    {
        isActiveInBattle = false;
        yield return new WaitForSeconds(2);
        BattleManager.Instance.CharacterEndedTurn();
    }
}
