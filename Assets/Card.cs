using JL.Splitting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private GameObject trailGobj;
    private Fruit temp;
    private bool yes = true;

    private void OnTriggerEnter(Collider other)
    {
        Fruit fruit = other.GetComponentInParent<Fruit>();
        if (fruit && fruit != temp)
        {
            Debug.Log(fruit);
            temp = fruit;
            fruit.Spliit(new PointPlane(transform.position, transform.rotation));
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
    public void ActivateTrail()
    {
        trailGobj.SetActive(true);
    }

    public void DeactivateTrail() 
    {
        trailGobj.SetActive(false);
    }
}
