using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TrajectoryController : MonoBehaviour
{
    [SerializeField]
    private GameObject trajectoryPointPrefab;
    [SerializeField]
    private int trajectroyPointsCount;
    [SerializeField]
    private GameObject[] trajecetoryPoints;

    private void Awake()
    {
        Init();
        DeactivatePoints();
    }
    private void Init()
    {
        trajecetoryPoints = new GameObject[trajectroyPointsCount];

        for (int i = 0; i < trajectroyPointsCount; i++)
        {
            GameObject curPoint = Instantiate(trajectoryPointPrefab, transform);
            trajecetoryPoints[i] = curPoint;
        }
    }

    public void ActivatePoints()
    {
        for (int i = 0; i < trajecetoryPoints.Length; i++)
        {
            trajecetoryPoints[i].SetActive(true);
        }
    }

    public void DeactivatePoints()
    {
        for (int i = 0; i < trajecetoryPoints.Length; i++)
        {
            trajecetoryPoints[i].SetActive(false);
        }
    }

    public void UpdateTrajectoryPosition(QuadraticCurve curve)
    {
        for (int i = 0; i < trajecetoryPoints.Length; i++)
        {
            trajecetoryPoints[0].gameObject.SetActive(false);
            trajecetoryPoints[i].transform.position = curve.Evaluate(i / (float)trajecetoryPoints.Length);
        }
    }

}
