using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public BattleHandler battleHandler;
    public BattleCardInfo battleCardInfo;
    public BattleCardHandler battleCardHandler;
    public EndPlayerTurn endPlayerTurn;

    public Vector2 startObjectPos;
    public Vector2 endPos;
    public Vector2 startObjectScale;
    public Vector2 endLocalScale;

    public bool lockPos = false;

    public GameObject target;
    public float lerpDurationOne = 1f;
    public float lerpDurationHalf = 0.5f;
    public float lerpDurationQuarter = 0.25f;

    private void Start() 
    {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        endPlayerTurn = GameObject.Find("EndTurnButton").GetComponent<EndPlayerTurn>();
        battleCardInfo = this.gameObject.GetComponent<BattleCardInfo>();
        battleCardHandler = GameObject.Find("NetworkManager").GetComponent<BattleCardHandler>();
        startObjectPos = transform.position;
        gameObject.transform.localPosition = new Vector2(0f, 0f);
        startObjectScale = transform.localScale;
    }

    private void FixedUpdate() 
    {
        if(battleHandler.moveCardsToUsedCardsAnimation == true && battleCardInfo.allow_to_animate == true)
        {
            endPos = new Vector2(370, 154);
            endLocalScale = new Vector2(0.63f, 0.53f);
            StartCoroutine(AnimateMovingCardsToUsedCards());
        }

        if(battleHandler.moveCardsToPlayerCardsPanelAnimation == true && battleCardInfo.allow_to_animate == true)
        {
            endPos = new Vector2(955, -271);
            endLocalScale = new Vector2(1f, 0.88f);
            StartCoroutine(AnimateMovingCardsToPlayerCardsPanel());
        }

        if(battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation == true && battleCardInfo.allow_to_animate == true)
        {
            endLocalScale = new Vector2(0f, 0f);
            StartCoroutine(AnimateMovingCardsSidewaysInPlayerCardsPanel());
        }

        if(battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation2 == true && battleCardInfo.allow_to_animate == true)
        {
            endLocalScale = new Vector2(1f, 0.88f);
            StartCoroutine(AnimateMovingCardsSidewaysInPlayerCardsPanel2());
        }

        if(battleHandler.moveCardsFromUsedCardsToDeckCardsAnimation == true && battleCardInfo.allow_to_animate == true)
        {
            endPos = new Vector2(0, 0);
            endLocalScale = new Vector2(0.4272f, 0.370f);
            StartCoroutine(AnimateMovingCardsFromUsedCardsToDeckCardsToPick());
        }
    }

    IEnumerator AnimateMovingCardsToUsedCards()
    {
        if (lockPos == false)
        {
            startObjectPos = transform.localPosition;
            startObjectScale = transform.localScale;
            lockPos = true;
        }

        float timeElapsed = 0;
        while(timeElapsed < lerpDurationHalf)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationHalf;

            transform.localPosition = Vector2.Lerp(startObjectPos, endPos, percentageComplete);
            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        transform.localPosition = endPos;
        transform.localScale = endLocalScale;
        battleCardInfo.allow_to_animate = false;
        battleHandler.moveCardsToUsedCardsAnimation = false;
        lockPos = false;

        StopAllCoroutines();
    }

    IEnumerator AnimateMovingCardsToPlayerCardsPanel()
    {
        if (lockPos == false)
        {
            startObjectPos = transform.localPosition;
            startObjectScale = transform.localScale;
            lockPos = true;
        }

        float timeElapsed = 0;
        while(timeElapsed < lerpDurationHalf)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationHalf;

            transform.localPosition = Vector2.Lerp(startObjectPos, endPos, percentageComplete);
            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        battleCardInfo.TurnOnButton();
        transform.localPosition = endPos;
        transform.localScale = endLocalScale;
        battleHandler.moveCardsToPlayerCardsPanelAnimation = false;
        lockPos = false;

        StopAllCoroutines();
    }

    IEnumerator AnimateMovingCardsSidewaysInPlayerCardsPanel()
    {
        if (lockPos == false)
        {
            startObjectScale = transform.localScale;
            lockPos = true;
        }
        float timeElapsed = 0;
        while(timeElapsed < lerpDurationHalf)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationHalf;

            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        lockPos = false;
        battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation = false;

        StopAllCoroutines();

        battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation2 = true;
    }

    IEnumerator AnimateMovingCardsSidewaysInPlayerCardsPanel2()
    {
        battleCardInfo.AssignCardImage();

        if (lockPos == false)
        {
            startObjectScale = transform.localScale;
            lockPos = true;
        }
        float timeElapsed = 0;
        while(timeElapsed < lerpDurationHalf)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationHalf;

            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        endPlayerTurn.MakeButtonVisible();

        transform.localScale = endLocalScale;
        battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation2 = false;
        lockPos = false;

        StopAllCoroutines();
    }

    IEnumerator AnimateMovingCardsFromUsedCardsToDeckCardsToPick()
    {
        if (lockPos == false)
        {
            startObjectPos = transform.localPosition;
            startObjectScale = transform.localScale;
            lockPos = true;
        }

        float timeElapsed = 0;
        while(timeElapsed < lerpDurationQuarter)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationQuarter;

            transform.localPosition = Vector2.Lerp(startObjectPos, endPos, percentageComplete);
            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        this.GetComponent<BattleCardInfo>().allow_to_animate = false;
        transform.localPosition = endPos;
        transform.localScale = endLocalScale;
        battleHandler.moveCardsFromUsedCardsToDeckCardsAnimation = false;
        lockPos = false;

        StopAllCoroutines();
    }
}