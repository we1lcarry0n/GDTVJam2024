using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private float speed;
    [field : SerializeField] public List<CharacterPlayable> playableCharacters {  get; private set; }

    [field : SerializeField] public Slider[] playableCharactersHealthBars { get; private set; }
    [field : SerializeField] public List<Button> playerSkillImages { get; private set; }
    [field : SerializeField] public TMP_Text characterNameText { get; private set; }
    [field: SerializeField] public TMP_Text characterHealthValueText{ get; private set; }
    [field : SerializeField] public TMP_Text characterSkillDescriptionText { get; private set; }    

    public bool isFight {  get; private set; }
    public bool isInInterraction;

    public bool isPressed { get; private set; }

    private GameManager gameManager;
    private List<CharacterPlayable> characterPlayablesDefeated;

    private void Awake()
    {
        Instance = this;
        characterPlayablesDefeated = new List<CharacterPlayable>();
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
            if (characterPlayablesDefeated.Count == playableCharacters.Count && characterPlayablesDefeated.Count != 0)
            {
                BattleManager.Instance.EndBattlePlayerDefeated();
            }
            return;
        }
        if (isInInterraction)
        {
            return;
        }
        if (isPressed)
        {
            transform.position += new Vector3(0, 0, 1 * speed * Time.deltaTime);
            foreach (CharacterPlayable character in playableCharacters)
            {
                character.GetAnimator().SetFloat("speed", 1);
            }
            return;
        }
        float horizontalMovement = Input.GetAxis("Horizontal");
        if (transform.position.z < -40.5f && horizontalMovement < 0)
        {
            return;
        }
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

    public void ClearDefeatedCharacters()
    {
        characterPlayablesDefeated.Clear();
    }

    public void AddCharacterToDefeatedList(CharacterPlayable character)
    {
        characterPlayablesDefeated.Add(character);
    }

    public void RemoveCharacterFromDefeatedList(CharacterPlayable character)
    {
        characterPlayablesDefeated.Remove(character);
    }

    public void OnMovePressBegin()
    {
        isPressed = true;
    }

    public void OnMovePressEnd()
    {
        isPressed = false;
    }
}
