using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeManVisual : MonoBehaviour
{
    [SerializeField] private GameObject smokeProjectile;

    [SerializeField] private Transform projectileLaunchTransform;
    [SerializeField] private Transform projectileLaunchUpper;
    [SerializeField] private Transform projectileLaunchLower;

    public void UseSkill1Projectile()
    {
        GameObject arrowObject = Instantiate(smokeProjectile, projectileLaunchTransform);
        Destroy(arrowObject, .4f);
    }

    public void UseSkill2Projectile()
    {
        GameObject arrowObject1 = Instantiate(smokeProjectile, projectileLaunchUpper);
        GameObject arrowObject2 = Instantiate(smokeProjectile, projectileLaunchTransform);
        GameObject arrowObject3 = Instantiate(smokeProjectile, projectileLaunchLower);
        Destroy(arrowObject1, .4f);
        Destroy(arrowObject2, .7f);
        Destroy(arrowObject3, 1f);
    }
}
