using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticCurve : MonoBehaviour
{
    [SerializeField]
    Transform a, b;
    public Transform Control;

    public Vector3 Evaluate(float t)
    {
        Vector3 ac = Vector3.Lerp(a.position, Control.position, t);
        Vector3 cb = Vector3.Lerp(Control.position, b.position, t);
        return Vector3.Lerp(ac, cb, t);

    }
    private void OnDrawGizmosSelected()
    {
        if (a == null || b == null || Control == null)
        {
            return;
        }
        for (int i = 0; i < 40; i++)
        {
            Gizmos.DrawWireSphere(Evaluate(i / 40f), 0.1f);
        }
        Gizmos.color = Color.yellow;
    }
}
