using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IComparable
{
    protected Animator animator;

    [SerializeField] protected int initiative;
    [SerializeField] protected GameObject activeIndicator;

    protected bool isActiveInBattle;


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

    private void ToggleActiveIndicator(bool isActive)
    {
        activeIndicator.SetActive(isActive);
    }

    public void ActivateCharacterInBattle()
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
}
