using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiSkillVisual : SkillVisual
{
    [SerializeField] private GameObject swingSkillOneParticle;
    [SerializeField] private GameObject slashSkillTwoParticle;

    public override void InitFromAnimations()
    {
        base.InitFromAnimations();
        // Do VFX, and everything from animations.
    }

    public void SkillOneActivateFX()
    {
        swingSkillOneParticle.SetActive(true);
    }

    public void SkillOneDeactivateFX()
    {
        swingSkillOneParticle.SetActive(false);
    }

    public void SkillTwoActivateFX()
    {
        GameObject slashFX = Instantiate(slashSkillTwoParticle);
        Destroy(slashFX, 1f);
    }

    public void SkillTwoDeactivateFX()
    {
        GameObject slashFX = Instantiate(slashSkillTwoParticle);
        Destroy(slashFX, 1f);
    }
}
