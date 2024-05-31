using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinePickupBuffs : MonoBehaviour
{

    [SerializeField] private GameObject ChoseUIPanel;
    [SerializeField] private GameObject ToolTipGO;
    [SerializeField] private AudioSource shrineAudioSource;

    private bool isInRange;
    private bool isUsed;


    private void Update()
    {
        if (isInRange && !isUsed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isUsed = true;
                shrineAudioSource.Play();
                ToolTipGO.SetActive(false);
                ChoseUIPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isUsed)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            ToolTipGO.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isUsed)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            ToolTipGO.SetActive(false);
        }
    }
}
