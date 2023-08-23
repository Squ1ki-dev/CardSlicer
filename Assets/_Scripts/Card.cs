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

    CardLevelView cardLevelView;

    public void SetCardLevelView(CardLevelView cardView)
    {
        cardLevelView = cardView;
    }

    private void OnTriggerEnter(Collider other)
    {
        Fruit fruit = other.GetComponentInParent<Fruit>();
        if (fruit && fruit != temp)
        {
            Debug.Log(fruit);
            temp = fruit;
            fruit.Spliit(new PointPlane(transform.position, transform.rotation));
        }

        //cardLevelView = FindObjectOfType<CardLevelView>();

        CubeMovement cube = other.GetComponent<CubeMovement>();
        if(cube)
        {
            Debug.LogError($"DEAD");
            cardLevelView.RespawnCard();
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
