using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isFight {  get; private set; }

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
        PlayerManager.Instance.ToggleFight(isFight);
    }
}
