using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSkillVisual : MonoBehaviour
{
    [SerializeField] private GameObject kunaiProjectile;
    [SerializeField] private GameObject cursedPaperProjectile;
    [SerializeField] private GameObject blessedPaperProjectile;

    [SerializeField] private Transform projectileLaunchTransform;
    [SerializeField] private Transform projectileLaunchUpper;
    [SerializeField] private Transform projectileLaunchLower;

    [SerializeField] private AudioSource papersSkillAS;

    public void KunaiThrowSkill1()
    {
        GameObject arrowObject = Instantiate(kunaiProjectile, projectileLaunchTransform);
        Destroy(arrowObject, 1.2f);
    }

    public void CursedPapersThrowSkill2()
    {
        papersSkillAS.Play();
        GameObject arrowObject1 = Instantiate(cursedPaperProjectile, projectileLaunchUpper);
        GameObject arrowObject2 = Instantiate(cursedPaperProjectile, projectileLaunchTransform);
        GameObject arrowObject3 = Instantiate(cursedPaperProjectile, projectileLaunchLower);
        Destroy(arrowObject1, 1.2f);
        Destroy(arrowObject2, 0.9f);
        Destroy(arrowObject3, 0.6f);
    }

    public void BlessedPapersThrowSkill3()
    {
        papersSkillAS.Play();
        GameObject arrowObject1 = Instantiate(blessedPaperProjectile, projectileLaunchUpper);
        GameObject arrowObject2 = Instantiate(blessedPaperProjectile, projectileLaunchTransform);
        GameObject arrowObject3 = Instantiate(blessedPaperProjectile, projectileLaunchLower);
        Destroy(arrowObject1, .3f);
        Destroy(arrowObject2, .6f);
        Destroy(arrowObject3, .9f);
    }
}
