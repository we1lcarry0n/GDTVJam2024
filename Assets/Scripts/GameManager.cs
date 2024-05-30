using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isFight {  get; private set; }

    [SerializeField] private AudioSource backgroundMusicAudioSource;
    [SerializeField] private AudioClip adventuringAudioClip;
    [SerializeField] private AudioClip battleAudioClip;

    [SerializeField] private PlayerSelectionOverlayController playerSelectionOverlayController;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TriggerFight(false);
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
}
