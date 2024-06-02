using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isFight {  get; private set; }

    [SerializeField] private AudioSource backgroundMusicAudioSource;
    [SerializeField] private AudioClip adventuringAudioClip;
    [SerializeField] private AudioClip battleAudioClip;

    [SerializeField] private PlayerSelectionOverlayController playerSelectionOverlayController;

    [SerializeField] private GameObject journalGameObject;

    [SerializeField] private AudioSource buttonPressAS;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerManager.Instance.isInInterraction = true;
            journalGameObject.SetActive(true);
        }
    }
    public void TriggerFight(bool fight)
    {
        isFight = fight;
        if (fight)
        {
            playerSelectionOverlayController.DeselectAll();
            backgroundMusicAudioSource.clip = battleAudioClip;
            backgroundMusicAudioSource.Play();
        }
        else
        {
            playerSelectionOverlayController.SelectFirst();
            backgroundMusicAudioSource.clip = adventuringAudioClip;
            backgroundMusicAudioSource.Play();
        }
    }

    public void PlayButtonAudioClip()
    {
        buttonPressAS.Play();
    }
}
