using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueScripts : MonoBehaviour
{
    [SerializeField] private string englishPrologue;
    [SerializeField] private string ukrPrologue;

    [SerializeField] private TMP_Text prologueText;

    private void Start()
    {
        StartCoroutine(TextPrintingRoutine());
    }

    private IEnumerator TextPrintingRoutine()
    {
        yield return new WaitForSeconds(1f);
        if (PlayerPrefs.GetInt("lang") == 0)
        {
            foreach (char c in englishPrologue)
            {
                prologueText.text += c;
                yield return new WaitForSeconds(.05f);
            }
        }
        else
        {
            foreach (char c in ukrPrologue)
            {
                prologueText.text += c;
                yield return new WaitForSeconds(.05f);
            }
        }
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
