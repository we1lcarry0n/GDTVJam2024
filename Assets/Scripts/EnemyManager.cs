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
        if (defeatedEnemies.Count == enemyCharacters.Count && defeatedEnemies.Count != 0)
        {
            ConsealAllEnemyUI();
            ClearAllLists();
            //Trigger All Remove Enemy from Scene functions in every enemy.
            BattleManager.Instance.EndBattleEnemiesDefeated();
        }
    }

    private void ConsealAllEnemyUI()
    {
        foreach(Image image in enemyCharactersHealthBars)
        {
            image.fillAmount = 1;
        }
    }

    private void ClearAllLists()
    {
        foreach (CharacterEnemy enemy in defeatedEnemies)
        {
            enemy.GetComponent<HealthEnemy>().SetCharacterDestructionTimer(4.5f);
        }
        defeatedEnemies.Clear();
        enemyCharacters.Clear();
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
