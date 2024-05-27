using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    public List<CharacterEnemy> enemyCharacters {  get; private set; }

    private List<CharacterEnemy> defeatedEnemies;

    [field : SerializeField] public Image[] enemyCharactersHealthBars {  get; private set; }


    private void Awake()
    {
        Instance = this;
        enemyCharacters = new List<CharacterEnemy>();
        defeatedEnemies = new List<CharacterEnemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (defeatedEnemies.Count == enemyCharacters.Count)
        {
            //Trigger All Remove Enemy from Scene functions in every enemy.
            BattleManager.Instance.EndBattleEnemiesDefeated();
        }
    }

    public void AddElemenToCharactersEnemy(CharacterEnemy enemy)
    {
        enemyCharacters.Add(enemy);
    }

    public void RemoveEnemyFromList(CharacterEnemy enemy)
    {
        defeatedEnemies.Add(enemy);
    }
}
