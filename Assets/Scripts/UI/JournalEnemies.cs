using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalEnemies : MonoBehaviour
{
    [SerializeField] private string[] englishEnemiesNames;
    [SerializeField] private string[] urkEnemiesNames;

    [SerializeField] private string[] englishEnemiesDescriptions;
    [SerializeField] private string[] ukrEnemiesDescriptions;

    [SerializeField] private Sprite[] enemiesSprites;
    [SerializeField] private TMP_Text[] enemiesNamesButtonsText;

    [SerializeField] private TMP_Text enemyDescriptionField;
    [SerializeField] private Image enemySpriteImage;

    private void Start()
    {
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            for (int i = 0; i< englishEnemiesNames.Length; i++)
            {
                enemiesNamesButtonsText[i].text = englishEnemiesNames[i];
            }
        }
        else
        {
            for (int i = 0; i < englishEnemiesNames.Length; i++)
            {
                enemiesNamesButtonsText[i].text = urkEnemiesNames[i];
            }
        }
        Button1Press();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerManager.Instance.isInInterraction = false;
            gameObject.SetActive(false);
        }
    }

    public void Button1Press()
    {
        enemySpriteImage.sprite = enemiesSprites[0];
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            enemyDescriptionField.text = englishEnemiesDescriptions[0];
        }
        else
        {
            enemyDescriptionField.text = ukrEnemiesDescriptions[0];
        }
    }

    public void Button2Press()
    {
        enemySpriteImage.sprite = enemiesSprites[1];
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            enemyDescriptionField.text = englishEnemiesDescriptions[1];
        }
        else
        {
            enemyDescriptionField.text = ukrEnemiesDescriptions[1];
        }
    }

    public void Button3Press()
    {
        enemySpriteImage.sprite = enemiesSprites[2];
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            enemyDescriptionField.text = englishEnemiesDescriptions[2];
        }
        else
        {
            enemyDescriptionField.text = ukrEnemiesDescriptions[2];
        }
    }

    public void Button4Press() 
    {
        enemySpriteImage.sprite = enemiesSprites[3];
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            enemyDescriptionField.text = englishEnemiesDescriptions[3];
        }
        else
        {
            enemyDescriptionField.text = ukrEnemiesDescriptions[3];
        }
    }

    public void Button5Press()
    {

    }

}
