using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : Health
{
    public override void Die()
    {
        base.Die();
        GetComponent<Character>().GetAnimator().SetBool("isDefeated", true);
        //EnemyManager.Instance.RemoveEnemyFromList(GetComponent<CharacterEnemy>());
        GetComponent<CharacterPlayable>().isDefeated = true;
        PlayerManager.Instance.AddCharacterToDefeatedList(GetComponent<CharacterPlayable>());
    }

    public override void UpdateHealthUIBar(float percentageAmount)
    {
        PlayerManager.Instance.playableCharactersHealthBars[indexOnScene].value = percentageAmount;
    }
}
