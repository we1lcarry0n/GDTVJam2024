using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    private List<Character> charactersInBattle;

    private int activeCharacterInBattleIndex;
    private void Awake()
    {
        Instance = this;
        charactersInBattle = new List<Character>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isFight)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (Character character in charactersInBattle)
            {
                Debug.Log(character.gameObject.name);
            }
        }
    }

    public void AddCharacterToInitiativeList(Character character)
    {
        charactersInBattle.Add(character);
        charactersInBattle.Sort();
        charactersInBattle.Reverse();
    }

    public void ClearInitiative()
    {
        charactersInBattle.Clear();
    }

    public void ActivateFirstCharacter()
    {
        activeCharacterInBattleIndex = 0;
        charactersInBattle[activeCharacterInBattleIndex].ActivateCharacterInBattle();
    }

    public void CharacterEndedTurn()
    {
        charactersInBattle[activeCharacterInBattleIndex].DeactivateCharacterInBattle();
        if (activeCharacterInBattleIndex == charactersInBattle.Count - 1)
        {
            activeCharacterInBattleIndex = 0;
        }
        else
        {
            activeCharacterInBattleIndex++;
        }
        charactersInBattle[activeCharacterInBattleIndex].ActivateCharacterInBattle();
        Debug.Log($"Active character is {activeCharacterInBattleIndex}");
    }
}
                                                                                                                                                                        