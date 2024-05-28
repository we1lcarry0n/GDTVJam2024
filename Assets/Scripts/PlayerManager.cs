using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private float speed;
    [field : SerializeField] public List<CharacterPlayable> playableCharacters {  get; private set; }

    [SerializeField] public Image[] playableCharactersHealthBars { get; private set; }

    public bool isFight {  get; private set; }
    private GameManager gameManager;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isFight)
        {
            return;
        }
        float horizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(0, 0, horizontalMovement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FightTrigger"))
        {
            ToggleFight(true);
            gameManager.TriggerFight(true);
            other.GetComponent<FightTrigger>().InitiateFight();
            Destroy(other.gameObject);
            BattleManager.Instance.ActivateFirstCharacter();
        }
    }

    public void ToggleFight(bool fight)
    {
        if (fight)
        {
            foreach (CharacterPlayable character in playableCharacters)
            {
                BattleManager.Instance.AddCharacterToInitiativeList(character as Character);
                character.CharacterEnteredBattle();
            }
            Debug.Log("The fight has begun!");
        }
        if (!fight)
        {
            foreach(CharacterPlayable character in playableCharacters)
            {
                character.CharacterExitedBattle();
            }
            Debug.Log("The fight has ended!");
        }
        isFight = fight;
    }
}
