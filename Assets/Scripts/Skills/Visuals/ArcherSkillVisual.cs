using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkillVisual : SkillVisual
{
    [SerializeField] private Transform arrowSpawnTransform;
    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private Transform arrowSpawnTransformBottom;
    [SerializeField] private Transform arrowSpawnTransformUpper;

    [SerializeField] private AudioSource arrowSpawnAS;

    public void AttackOneArrowSpawn()
    {
        arrowSpawnAS.Play();
        GameObject arrowObject = Instantiate(arrowPrefab, arrowSpawnTransform);
        Destroy(arrowObject, .6f);
    }

    public void AttackTwoArrowSpawn()
    {
        arrowSpawnAS.Play();
        GameObject arrowObject1 = Instantiate(arrowPrefab, arrowSpawnTransformUpper);
        GameObject arrowObject2 = Instantiate(arrowPrefab, arrowSpawnTransform);
        GameObject arrowObject3 = Instantiate(arrowPrefab, arrowSpawnTransformBottom);
        Destroy(arrowObject1, .6f);
        Destroy(arrowObject2, .5f);
        Destroy(arrowObject3, .4f);
    }
}
