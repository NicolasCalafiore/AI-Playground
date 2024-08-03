using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public static class UnitCoroutines
{
    private static IEnumerator EnableAwarenessSphereTemporarily(GameObject awarenessSphere)
    {
        awarenessSphere.SetActive(true);
        yield return new WaitForSeconds(2f);
        awarenessSphere.SetActive(false);
    }

    private static IEnumerator EnableEngageSphereTemporarily(GameObject engageSphere)
    {
        engageSphere.SetActive(true);
        yield return new WaitForSeconds(2f);
        engageSphere.SetActive(false);
    }

}
