using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnemy : Character
{

    // Update is called once per frame
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
