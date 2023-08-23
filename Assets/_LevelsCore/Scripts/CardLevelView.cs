using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using Tools.Reactive;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardLevelView : BaseLevelView
{
    [SerializeField]
    private QuadraticCurve curve;
    private float sampleTime;
    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private Card cardPrefab;
    private Card currentCard;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minX, maxX;
    [SerializeField]
    private int attemptsCount = 1;
    int attempts = 0;
    [SerializeField]
    TrajectoryController trajectoryController;
    [SerializeField]
    FruitController fruitController;
    private float posX = 0;
    private bool isSelectTrajectory, isStartMove = false;
    private bool gameCompleted;

    private void Awake() => Application.targetFrameRate = 60;

    public override void Init(LevelModel model)
    {
        this.model = model;
        WindowManager.Instance.Show<LevelScreen>().Show(model);
        fruitController.Init(
            onSliceFruit: scores =>
            {
                model.scores.value = scores;
            });

        CreateCard();
    }

    private void Update()
    {
        if (gameCompleted) return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && !isStartMove)
        {
            if (isSelectTrajectory == false)
                isSelectTrajectory = true;
            posX = 0;
            trajectoryController.ActivatePoints();
        }
        else if (Input.GetKey(KeyCode.Mouse0) && !isStartMove)
        {
            if (isSelectTrajectory)
            {
                float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 10f;
                posX += mouseX;
                posX = Mathf.Clamp(posX, minX, maxX);
                Vector3 startPos = curve.Control.transform.position;
                Vector3 endPos = new Vector3(posX * 1f, curve.Control.transform.position.y, curve.Control.transform.position.z);
                curve.Control.transform.position = Vector3.LerpUnclamped(startPos, endPos, 10f * Time.deltaTime);
                currentCard.transform.forward = curve.Evaluate(sampleTime + 0.001f) - currentCard.transform.position;
                trajectoryController.UpdateTrajectoryPosition(curve);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && !isStartMove)
        {
            if (isSelectTrajectory)
            {
                isSelectTrajectory = false;
                isStartMove = true;
                trajectoryController.DeactivatePoints();
                currentCard.ActivateTrail();
            }
        }
        else if (!isSelectTrajectory && isStartMove && currentCard != null)
        {
            sampleTime += Time.deltaTime * speed;
            currentCard.transform.position = curve.Evaluate(sampleTime);
            if (sampleTime <= 1f)
            {
                currentCard.transform.forward = curve.Evaluate(sampleTime + 0.001f) - currentCard.transform.position;
            }
            else if (sampleTime >= 1f)
            {
                attempts++;
                if (fruitController.fruitsCount <= 0)
                {
                    OnWonLevel();
                    gameCompleted = true;
                }
                else if (attempts >= attemptsCount)
                {
                    OnLoseLevel();
                    gameCompleted = true;
                }
                else
                {
                    currentCard.DeactivateTrail();
                    currentCard.Dead();
                    currentCard = null;
                    isSelectTrajectory = false;
                    isStartMove = false;
                    CreateCard();
                }
            }
        }
    }

    private void CreateCard()
    {
        Card card = Instantiate(cardPrefab, spawnPos);
        card.transform.localScale = Vector3.zero;
        card.transform.DOScale(Vector3.one, 0.1f);
        currentCard = card;
        sampleTime = 0f;
    }
}
