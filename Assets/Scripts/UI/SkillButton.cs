using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    private Animation animation;

    private string skillDescription;
    private CharacterPlayable currentActiveCharacter;

    [SerializeField] private int skillIndex;


    private void Start()
    {
        animation = GetComponent<Animation>();
    }

    public void OnMouseHoverEnter()
    {
        animation.Play();
        PlayerManager.Instance.characterSkillDescriptionText.text = skillDescription;
    }

    public void OnMouseHoverExit()
    {
        animation.Stop();
        transform.localScale = Vector3.one;
        PlayerManager.Instance.characterSkillDescriptionText.text = "";
    }

    public void OnUse()
    {
        if (!GameManager.Instance.isFight)
        {
            return;
        }
        if (!currentActiveCharacter.isActiveInBattle)
        {
            return;
        }
        if (skillIndex == 0)
        {
            currentActiveCharacter.UseSkill1();
            currentActiveCharacter.DeactivateCharacterOnMouseClickSkill();
        }
        if (skillIndex == 1)
        {
            currentActiveCharacter.UseSkill2();
            currentActiveCharacter.DeactivateCharacterOnMouseClickSkill();
        }
        if (skillIndex == 2)
        {
            currentActiveCharacter.UseSkill3();
            currentActiveCharacter.DeactivateCharacterOnMouseClickSkill();
        }
    }

    public void SetSkillDescription(string skillDescription)
    {
        this.skillDescription = skillDescription;
    }

    public void SetCurrentActiveCharacter(CharacterPlayable character)
    {
        currentActiveCharacter = character;
    }
}
