using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private bool isXMove, isYMove;
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveDuration = 1f;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;

        if (isXMove) MoveCubeX();
        if (isYMove) MoveCubeY();
    }

    private void MoveCubeX()
    {
        Vector3 targetPosition = originalPosition + new Vector3(moveDistance, 0f, 0f);
        transform.DOMove(targetPosition, moveDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void MoveCubeY()
    {
        Vector3 targetPosition = originalPosition + new Vector3(0f, moveDistance, 0f);
        transform.DOMove(targetPosition, moveDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
