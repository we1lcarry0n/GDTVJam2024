using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private float speed;
    [SerializeField] private List<CharacterPlayable> playableCharacters;

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
        if (isFight)
        {
            foreach (CharacterPlayable character in playableCharacters)
            {
                BattleManager.Instance.AddCharacterToInitiativeList(character as Character);
                character.CharacterEnteredBattle();
            }
        }
        isFight = fight;
    }
}
