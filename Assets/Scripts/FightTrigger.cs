using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    [SerializeField] private List<CharacterEnemy> enemyCharacters;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateFight()
    {
        foreach (CharacterEnemy character in enemyCharacters)
        {
            EnemyManager.Instance.AddElemenToCharactersEnemy(character);
            BattleManager.Instance.AddCharacterToInitiativeList(character as Character);
            character.InitiateFight();
        }
    }
}
