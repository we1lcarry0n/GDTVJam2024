using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
    [field: SerializeField] private float skillDamage;
    [field: SerializeField] private int[] targetsToDamage;

    public void Init(List<Transform> targets, float damageMultiplierFromCharacter)
    {
        foreach (int i in targetsToDamage)
        {
            targets[i].GetComponent<Health>().ModifyHealth(-skillDamage * damageMultiplierFromCharacter);
        }
    }
}
