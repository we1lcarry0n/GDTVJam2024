using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : Health
{
    public override void Die()
    {
        base.Die();
    }

    public override void UpdateHealthUIBar(float percentageAmount)
    {
        PlayerManager.Instance.playableCharactersHealthBars[indexOnScene].value = percentageAmount;
    }
}
