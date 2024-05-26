using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private List<CharacterEnemy> enemyCharacters;

    private void Awake()
    {
        Instance = this;
        enemyCharacters = new List<CharacterEnemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddElemenToCharactersEnemy(CharacterEnemy enemy)
    {
        enemyCharacters.Add(enemy);
    }
}
