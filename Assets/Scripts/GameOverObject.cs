using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverObject : MonoBehaviour
{
    [SerializeField] private AudioSource gameOverAS;
    [SerializeField] private AudioSource gameGongAS;
    [SerializeField] private AudioSource gameOverFogAS;

    [SerializeField] private GameObject gameOverFog1;
    [SerializeField] private GameObject gameOverFog2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.Instance.isInInterraction = true;
            StartCoroutine(GameOverRoutine());
        }
    }

    private IEnumerator GameOverRoutine()
    {
        gameOverAS.Play();
        yield return new WaitForSeconds(2f);
        gameOverFog1.SetActive(true);
        gameOverFogAS.Play();
        yield return new WaitForSeconds(1.5f);
        gameOverFog2.SetActive(true);
        gameGongAS.Play();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }
}
