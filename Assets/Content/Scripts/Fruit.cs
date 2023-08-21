using DG.Tweening;
using JL.Splitting;
using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private FruitController fruitController;
    [SerializeField]
    private Vector3 rotateVector;
    [SerializeField]
    private float speedRotate;
    [SerializeField]
    private Splittable splittable;
    [SerializeField]
    private bool isSplitable = false;
    private GameObject[] parts = new GameObject[2];
    [SerializeField]
    private GameObject effect;
    public void Spliit(PointPlane pointPlane)
    {
        if (isSplitable)
        {
            splittable.SplitAsync(pointPlane,MySplitResult);
        }
    }

    private void MySplitResult(SplitResult splitResult)
    {
        isSplitable = false;
        Instantiate(effect, transform.position, Quaternion.identity);

        Rigidbody rb1 = splitResult.posObject.GetComponent<Rigidbody>();
        Rigidbody rb2 = splitResult.negObject.GetComponent<Rigidbody>();

        parts[0] = rb1.gameObject;
        parts[1] = rb2.gameObject;

        rb1.useGravity = true;
        rb1.AddForce(new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)) * 1f, ForceMode.Impulse);
        rb2.useGravity = true;
        rb2.AddForce(new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)) * 1f, ForceMode.Impulse);

        DOVirtual.DelayedCall(2f, Dead);
    }

    public void Init(FruitController fruitController)
    {
        this.fruitController = fruitController;
    }

    public void Dead()
    {
        for (int i = 0; i < parts.Length; i++)
        {
           if (parts[i]!=null)
               parts[i].gameObject.transform.DOScale(Vector3.zero, 1.2f);
        }
        fruitController.RemoveFromList(this);
        Destroy(gameObject,1.2f);
    }

    private void Update()
    {
        if (isSplitable)
        {
            transform.Rotate(rotateVector*speedRotate*Time.deltaTime);
        }
    }
}
