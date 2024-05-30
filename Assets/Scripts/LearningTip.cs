using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LearningTip : MonoBehaviour
{
    [SerializeField] private TMP_Text learningTipText;
    [SerializeField] private string[] learningTipMessageText;

    [SerializeField] private GameObject learningTipGO;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            learningTipText.text = learningTipMessageText[0];
        }
        else
        {
            learningTipText.text = learningTipMessageText[1];
        }
        learningTipGO.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            learningTipGO.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            learningTipGO.SetActive(false);
        }
    }
}
