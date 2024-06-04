using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionOverlayController : MonoBehaviour
{
    [SerializeField] private GameObject[] characterSelectedObject;
    [SerializeField] private int characterToSelectIndex;


    public void SelectClickedCharacter()
    {
        if (PlayerManager.Instance.isInInterraction)
        {
            return;
        }
        if (GameManager.Instance.isFight)
        {
            return;
        }
        DeselectAll();
        characterSelectedObject[characterToSelectIndex].SetActive(true);
        PlayerManager.Instance.playableCharacters[characterToSelectIndex].ActivateCharacterOutsidebattle();
    }

    public void DeselectAll()
    {
        foreach (GameObject seelction in characterSelectedObject)
        {
            seelction.SetActive(false);
        }
    }

    public void SelectFirst()
    {
        DeselectAll();
        characterSelectedObject[0].SetActive(true);
        PlayerManager.Instance.playableCharacters[0].ActivateCharacterOutsidebattle();
    }
}
