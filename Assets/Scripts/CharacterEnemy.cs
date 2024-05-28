using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEnemy : Character
{

    [field : SerializeField] public Slider enemyHealthBar { get; private set; }

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
