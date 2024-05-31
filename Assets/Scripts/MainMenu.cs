using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    [field: SerializeField] private List<string> ukrButtons;
    [field: SerializeField] private List<string> engButtons;

    [field: SerializeField] private List<TMP_Text> buttonsText;

    [SerializeField] private GameObject urkCredits;
    [SerializeField] private GameObject englishCredits;

    [SerializeField] private AudioSource buttonClickAS;
    [SerializeField] private AudioSource startGameAS;

    private void Start()
    {
        UpdatedMenuLanguage();
    }

    public void PlayButton()
    {
        StartCoroutine(StartGameRoutine());
    }

    public void ExitButton()
    {
        PlayButtonClickAudio();
        Application.Quit();
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
        PlayButtonClickAudio();
    }

    public void CreditsButton()
    {
        creditsPanel.SetActive(true);
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            englishCredits.SetActive(true);
            urkCredits.SetActive(false);
        }
        else
        {
            englishCredits.SetActive(false);
            urkCredits.SetActive(true);
        }
        PlayButtonClickAudio();
    }

    public void BackButton()
    {
        creditsPanel.SetActive(false);
        PlayButtonClickAudio();
    }

    public void SetUkrainianLanguage()
    {
        PlayerPrefs.SetInt("lang", 1);
        UpdatedMenuLanguage();
        settingsPanel.SetActive(false);
        PlayButtonClickAudio();
    }

    public void SetEnglishLanguage()
    {
        PlayerPrefs.SetInt("lang", 0);
        UpdatedMenuLanguage();
        settingsPanel.SetActive(false);
        PlayButtonClickAudio();
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

    private IEnumerator StartGameRoutine()
    {
        startGameAS.Play();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void PlayButtonClickAudio()
    {
        buttonClickAS.Play();
    }
}
