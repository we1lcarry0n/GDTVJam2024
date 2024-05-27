using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : Health
{
    public override void Die()
    {
        base.Die();
        GetComponent<Character>().GetAnimator().SetTrigger("isDefeated");
        EnemyManager.Instance.RemoveEnemyFromList(GetComponent<CharacterEnemy>());
        GetComponent<Character>().SetCharacterDefeated();
    }

    public override void UpdateHealthUIBar(float percentageAmount)
    {
        EnemyManager.Instance.enemyCharactersHealthBars[indexOnScene].fillAmount = percentageAmount + .01f;
    }

    public void SetCharacterDestructionTimer(float time)
    {
        StartCoroutine(DestroyThisCharacterRoutine(time));
    }

    private IEnumerator DestroyThisCharacterRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
