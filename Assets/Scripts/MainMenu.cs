using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [field: SerializeField] private List<string> ukrButtons;
    [field: SerializeField] private List<string> engButtons;

    [field: SerializeField] private List<TMP_Text> buttonsText;

    private void Start()
    {
        UpdatedMenuLanguage();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void SetUkrainianLanguage()
    {
        PlayerPrefs.SetInt("lang", 1);
        UpdatedMenuLanguage();
        settingsPanel.SetActive(false);
    }

    public void SetEnglishLanguage()
    {
        PlayerPrefs.SetInt("lang", 0);
        UpdatedMenuLanguage();
        settingsPanel.SetActive(false);
    }

    private void UpdatedMenuLanguage()
    {
        for (int i = 0; i < buttonsText.Count; i++)
        {
            if (PlayerPrefs.GetInt("lang") == 0)
            {
                buttonsText[i].text = engButtons[i];
            }
            else
            {
                buttonsText[i].text = ukrButtons[i];
            }
        }
    }

}
