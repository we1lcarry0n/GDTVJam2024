using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkanameVisual : MonoBehaviour
{
    [SerializeField] private Transform arrowSpawnTransform;
    [SerializeField] private GameObject blehPrefab;
    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private AudioSource arrowSpawnAS;

    public void AttackOne()
    {
        GameObject arrowObject = Instantiate(blehPrefab, arrowSpawnTransform);
        Destroy(arrowObject, .6f);
    }

    public void AttackTwo()
    {
        arrowSpawnAS.Play();
        GameObject arrowObject2 = Instantiate(arrowPrefab, arrowSpawnTransform);
        Destroy(arrowObject2, .7f);
    }
}
