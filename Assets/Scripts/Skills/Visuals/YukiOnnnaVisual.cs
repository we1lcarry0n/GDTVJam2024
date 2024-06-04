using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiOnnnaVisual : MonoBehaviour
{
    [SerializeField] private Transform arrowSpawnTransform;
    [SerializeField] private Transform blizzardSpawnTransform2;

    [SerializeField] private GameObject blizzPrefab;
    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private AudioSource blizzSpawnAS;

    public void UseSkill1Projectile()
    {
        GameObject arrowObject = Instantiate(arrowPrefab, arrowSpawnTransform);
        Destroy(arrowObject, .7f);
    }

    public void AttackTwo()
    {
        blizzSpawnAS.Play();
        GameObject arrowObject2 = Instantiate(blizzPrefab, blizzardSpawnTransform2);
        Destroy(arrowObject2, 2f);
    }
}
