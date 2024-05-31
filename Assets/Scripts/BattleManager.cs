using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    private List<Character> charactersInBattle;

    private int activeCharacterInBattleIndex;
    private ParticleSystem defeatedEnemiesParticles;
    private List<Character> defeatedCharacters;

    [SerializeField] private AudioSource defeatedAudioSource;

    private void Awake()
    {
        Instance = this;
        charactersInBattle = new List<Character>();
        defeatedCharacters = new List<Character>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isFight)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            //EndBattleEnemiesDefeated();
        }
    }

    public void AddCharacterToInitiativeList(Character character)
    {
        charactersInBattle.Add(character);
        charactersInBattle.Sort();
        charactersInBattle.Reverse();
    }

    public void SetDefeatedParticles(ParticleSystem defeatedParticles)
    {
        defeatedEnemiesParticles = defeatedParticles;
    }

    public void RemoveCharacterFromInitiativeList(Character character)
    {
        charactersInBattle.Remove(character);
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
        if (!GameManager.Instance.isFight)
        {
            return;
        }
        charactersInBattle[activeCharacterInBattleIndex].DeactivateCharacterInBattle();
        if (activeCharacterInBattleIndex == charactersInBattle.Count - 1)
        {
            activeCharacterInBattleIndex = 0;
        }
        else
        {
            activeCharacterInBattleIndex++;
        }
        if (!charactersInBattle[activeCharacterInBattleIndex].IsDefeated)
        {
            charactersInBattle[activeCharacterInBattleIndex].ActivateCharacterInBattle();
            Debug.Log($"Active character is {activeCharacterInBattleIndex}, so init count is {charactersInBattle.Count}");
            return;
        }
        else
        {
            CharacterEndedTurn();
            Debug.Log("Character was Defeated!");
            return;
        }
        
    }

    public void EndBattleEnemiesDefeated()
    {
        foreach (CharacterEnemy enemy in EnemyManager.Instance.enemyCharacters)
        {
            defeatedCharacters.Add(enemy);
        }
        /*for (int i = 0; i < EnemyManager.Instance.enemyCharacters.Count; i++)
        {
            defeatedCharacters[i] = EnemyManager.Instance.enemyCharacters[i];
        }*/
        foreach (Character character in charactersInBattle)
        {
            character.DeactivateCharacterInBattle();
        }
        ClearInitiative();
        StartCoroutine(DefeatedEnemiesRoutine());
        GameManager.Instance.TriggerFight(false);
        PlayerManager.Instance.ToggleFight(false);
    }

    public void EndBattlePlayerDefeated()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator DefeatedEnemiesRoutine()
    {
        yield return new WaitForSeconds(3);
        defeatedEnemiesParticles.Play();
        defeatedAudioSource.Play();
    }
}
                                                                                                                                                                        