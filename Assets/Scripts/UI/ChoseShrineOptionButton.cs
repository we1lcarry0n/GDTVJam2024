using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoseShrineOptionButton : MonoBehaviour
{
    [SerializeField] private float increaseMaxHpAmount;
    [SerializeField] private float healAllAmount;
    [SerializeField] private float increaseDmgPercentageAmount;

    [SerializeField] private TMP_Text optionDescription1;
    [SerializeField] private TMP_Text optionDescription2;
    [SerializeField] private TMP_Text optionDescription3;

    [SerializeField] private string[] optionDescription1Text;
    [SerializeField] private string[] optionDescription2Text;
    [SerializeField] private string[] optionDescription3Text;

    private void OnEnable()
    {
        PlayerManager.Instance.isInInterraction = true;
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            optionDescription1.text = optionDescription1Text[0];
            optionDescription2.text = optionDescription2Text[0];
            optionDescription3.text = optionDescription3Text[0];
        }
        else
        {
            optionDescription1.text = optionDescription1Text[1];
            optionDescription2.text = optionDescription2Text[1];
            optionDescription3.text = optionDescription3Text[1];
        }
    }

    public void IncreaseMaxHp()
    {
        foreach (CharacterPlayable character in PlayerManager.Instance.playableCharacters)
        {
            character.GetComponent<Health>().IncreaseMaxHP(increaseMaxHpAmount);
        }
        gameObject.SetActive(false);
        PlayerManager.Instance.isInInterraction = false;
    }

    public void HealAll()
    {
        foreach (CharacterPlayable character in PlayerManager.Instance.playableCharacters)
        {
            character.GetComponent<Health>().ModifyHealth(healAllAmount);
        }
        gameObject.SetActive(false);
        PlayerManager.Instance.isInInterraction = false;
    }

    public void IncreaseMaxDmg()
    {
        foreach (CharacterPlayable character in PlayerManager.Instance.playableCharacters)
        {
            character.IncreaseDmg(increaseDmgPercentageAmount);
        }
        gameObject.SetActive(false);
        PlayerManager.Instance.isInInterraction = false;
    }
}
