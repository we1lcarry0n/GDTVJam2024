using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiSkillVisual : SkillVisual
{
    [SerializeField] private GameObject swingSkillOneParticle;
    [SerializeField] private GameObject slashSkillTwoParticle;

    [SerializeField] private AudioSource swingSkill1AS;
    [SerializeField] private AudioSource slashSkill2AS;
    [SerializeField] private AudioSource battleCrySkill3AS;

    public override void InitFromAnimations()
    {
        base.InitFromAnimations();
        // Do VFX, and everything from animations.
    }

    public void SkillOneActivateFX()
    {
        swingSkillOneParticle.SetActive(true);
        swingSkill1AS.Play();
    }

    public void SkillOneDeactivateFX()
    {
        swingSkillOneParticle.SetActive(false);
    }

    public void SkillTwoActivateFX()
    {
        slashSkill2AS.Play();
        GameObject slashFX = Instantiate(slashSkillTwoParticle);
        Destroy(slashFX, 1f);
    }

    public void SkillTwoDeactivateFX()
    {
        GameObject slashFX = Instantiate(slashSkillTwoParticle);
        Destroy(slashFX, 1f);
    }

    public void Skill3ASActivate()
    {
        battleCrySkill3AS.Play();
    }
}
