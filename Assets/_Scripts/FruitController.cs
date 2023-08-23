using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    [SerializeField]
    private Fruit[] prefabs;
    [SerializeField]
    private Transform[] spawnPoints;
    private List<Fruit> currentsFruits = new List<Fruit>(20);
    int scores, attempts, maxAttempts;
    Action<int> onComplete, onCatch;
    public void Init(int attemptsCount, Action<int> onSliceFruit = null, Action<int> onCompleteSpawn = null)
    {
        CreatesFruits();
        onComplete = onCompleteSpawn;
        this.onCatch = onSliceFruit;
        maxAttempts = attemptsCount;
    }

    public void CreatesFruits()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Fruit fruit = Instantiate(prefabs.GetRandom(), spawnPoints[i]);
            fruit.Init(this);
            currentsFruits.Add(fruit);
        }
    }

    public void ClearField()
    {
        for (int i = 0; i < currentsFruits.Count; i++)
        {
            currentsFruits[i].Dead();
        }
        currentsFruits.Clear();
    }

    public void RemoveFromList(Fruit fruit)
    {
        currentsFruits.Remove(fruit);
        scores++;
        onCatch?.Invoke(scores);
        if (currentsFruits.Count <= 0)
        {
            attempts++;
            if (attempts >= maxAttempts) onComplete?.Invoke(scores);
            else DOVirtual.DelayedCall(0.5f, CreatesFruits);
        }
    }
}
