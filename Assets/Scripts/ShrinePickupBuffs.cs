using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinePickupBuffs : MonoBehaviour
{
    [SerializeField] private float increaseMaxHpAmount;
    [SerializeField] private float healAllAmount;
    [SerializeField] private float increaseDmgPercentageAmount;

    [SerializeField] private GameObject ChoseUIPanel;
    [SerializeField] private GameObject ToolTipGO;

    private bool isInRange;

    public void IncreaseMaxHp()
    {
        ToolTipGO.SetActive(false);
        ChoseUIPanel.SetActive(false);
        Destroy(gameObject);
    }

    public void HealAll()
    {
        ToolTipGO.SetActive(false);
        ChoseUIPanel.SetActive(false);
        Destroy(gameObject);
    }

    public void IncreaseMaxDmg()
    {
        ToolTipGO.SetActive(false);
        ChoseUIPanel.SetActive(false);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChoseUIPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            ToolTipGO.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            ToolTipGO.SetActive(false);
        }
    }
}
