using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    [SerializeField]
    private Fruit[] prefabs;
    [SerializeField]
    private Transform[] spawnPoints;
    private List<Fruit> currentsFruits = new List<Fruit>(20);

    private void Awake()
    {
        CreatesFruits();
    }

    public void CreatesFruits()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Fruit fruit = Instantiate(prefabs[Random.Range(0,prefabs.Length)],spawnPoints[i]);
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
        if (currentsFruits.Count <= 0)
        {
            Debug.Log($"Test Finish");
            DOVirtual.DelayedCall(0.5f, CreatesFruits);
        }
    }
}
