using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : Health
{
    public override void Die()
    {
        base.Die();
        EnemyManager.Instance.RemoveEnemyFromList(GetComponent<CharacterEnemy>());
        GetComponent<Character>().SetCharacterDefeated();
    }

    public override void UpdateHealthUIBar(float percentageAmount)
    {
        EnemyManager.Instance.enemyCharactersHealthBars[indexOnScene].fillAmount = percentageAmount + .01f;
    }
}
