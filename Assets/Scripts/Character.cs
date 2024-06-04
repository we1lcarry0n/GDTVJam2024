using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IComparable
{
    protected Animator animator;

    [SerializeField] protected int initiative;
    [SerializeField] protected GameObject activeIndicator;

    public bool isActiveInBattle;

    public bool IsDefeated { get; private set; }


    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public int GetInitiative()
    {
        return initiative;
    }

    public void SetCharacterDefeated()
    {
        IsDefeated = true;
    }

    public void UnsetCharacterDefeated()
    {
        IsDefeated = false;
    }

    private void ToggleActiveIndicator(bool isActive)
    {
        activeIndicator.SetActive(isActive);
    }

    public virtual void ActivateCharacterInBattle()
    {
        isActiveInBattle = true;
        ToggleActiveIndicator(true);
    }

    public void DeactivateCharacterInBattle()
    {
        isActiveInBattle = false;
        ToggleActiveIndicator(false);
    }

    public void EndTurn()
    {
        BattleManager.Instance.CharacterEndedTurn();
    }

    public int CompareTo(object obj)
    {
        var a = this;
        var b = obj as Character;

        if (a.GetInitiative() < b.GetInitiative())
        {
            return -1;
        }

        if (a.GetInitiative() > b.GetInitiative())
        {
            return 1;
        }
        return 0;
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
