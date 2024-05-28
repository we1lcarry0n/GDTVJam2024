using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
    [field: SerializeField] private float skillDamage;
    [field: SerializeField] private int[] targetsToDamage;
    [field: SerializeField] private float skillPrewarmTime;

    public IEnumerator Init(List<Transform> targets, float damageMultiplierFromCharacter)
    {
        yield return new WaitForSeconds(skillPrewarmTime);
        foreach (int i in targetsToDamage)
        {
            targets[i].GetComponent<Health>().ModifyHealth(-skillDamage * damageMultiplierFromCharacter);
        }
    }

    private void UseSkill()
    {
        
    }

    /*private IEnumerator skillPreWarmRoutine()
    {
        

    }*/
}
