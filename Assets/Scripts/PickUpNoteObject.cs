using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpNoteObject : MonoBehaviour
{
    [SerializeField] private GameObject ChoseUIPanel;
    [SerializeField] private GameObject ToolTipGO;

    [SerializeField] private TMP_Text noteText;
    [SerializeField] private string[] noteMessageText;

    private bool isInRange;
    private bool isInteracted;
    private bool isUsed;


    private void Update()
    {
        if (isInRange && !isUsed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isInteracted)
                {
                    PlayerManager.Instance.isInInterraction = true;
                    isInteracted = true;
                    ToolTipGO.SetActive(false);
                    ChoseUIPanel.SetActive(true);
                    if (PlayerPrefs.GetInt("lang") == 0)
                    {
                        noteText.text = noteMessageText[0];
                    }
                    else
                    {
                        noteText.text = noteMessageText[1];
                    }  
                }
                else
                {
                    isUsed = true;
                    ChoseUIPanel.SetActive(false);
                    PlayerManager.Instance.isInInterraction = false;
                }
                
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
