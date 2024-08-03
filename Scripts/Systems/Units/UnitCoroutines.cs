using System.Collections;
using UnityEngine;

public static class UnitCoroutines
{
    public static IEnumerator EnableAwarenessSphereTemporarily(GameObject awarenessSphere)
    {
        awarenessSphere.SetActive(true);
        yield return new WaitForSeconds(2f);
        awarenessSphere.SetActive(false);
    }

    public static IEnumerator EnableEngageSphereTemporarily(GameObject engageSphere)
    {
        engageSphere.SetActive(true);
        yield return new WaitForSeconds(2f);
        engageSphere.SetActive(false);
    }

    public static IEnumerator Attack(Unit unit)
    {
        yield return new WaitForSeconds(unit.attackSpeed);
        
        if (unit.target == null)
            yield break;
        
        Unit targetUnit = unit.target.GetComponent<Unit>();
        if (targetUnit == null)
            yield break;
        
        targetUnit.health -= unit.power;
        unit.UpdateUI();

        if (targetUnit.health <= 0)
            targetUnit.Death();
        
        if(unit.health > 0)
            unit.StartCoroutine(Attack(unit));
    }
}
